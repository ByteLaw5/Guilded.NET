using System;
using Newtonsoft.Json.Linq;
using System.IO;
using Guilded.NET;
using System.Threading.Tasks;
using Guilded.NET.Objects.Chat;
using System.Collections.Generic;
using System.Linq;

namespace GuildedNETTest {
    class Program {
        static void Main(string[] args) {
            // Read JSON "config.json"
            JObject obj = JObject.Parse(File.ReadAllText("./config.json"));
            // Get login info
            string email = obj["email"].Value<string>(),
                    password = obj["password"].Value<string>(),
                    prefix = obj["prefix"].Value<string>();
            Console.WriteLine($"Starting bot with prefix '{prefix}'");
            // Create new client
            using(GuildedUserClient client = new GuildedUserClient(email, password)) {
                // Assigns a lambda to message creation event
                client.MessageCreated += async (o, e) => {
                    // If bot itself posted this message, ignore the message
                    if(e.Message.AuthorId == client.CurrentUser.Id) return;
                    Console.WriteLine("Someone posted a message!");
                    // Turn message to string and get its content in markdown-style
                    string content = e.Message.ToString();
                    // Check if content starts with prefix
                    if(!content.StartsWith(prefix)) return;
                    // Remove the prefix and split the message by space
                    string[] split = content.Substring(prefix.Length, content.Length - prefix.Length).Split(' ');
                    // Get first argument, which is a command
                    string command = split[0];
                    // Get rest of the arguments, which are command arguments
                    IEnumerable<string> args = split.Skip(1);
                    switch(command) {
                        case "ping":
                            // Responds with `Pong!`
                            await client.SendMessageAsync(e.ChannelId,
                                // Generates new message
                                GMessage.Generate(new List<GNode>() {
                                    // Generates paragraph with leaf containing content `Pong!`
                                    GParagraphNode.Generate(GLeaf.Generate("Pong!"))
                                })
                            );
                            break;
                        default:
                            // Same like with pong, but also adds multiple leaves
                            await client.SendMessageAsync(e.ChannelId,
                                GMessage.Generate(new List<GNode>() {
                                    // Generate it with paragraph and leaves
                                    GParagraphNode.Generate(
                                        GLeaf.Generate("Uh oh! Could not find a command "),
                                        // Add GMarkType.InlineCode, which tells Guilded that it's inline code
                                        GLeaf.Generate(command, GMarkType.InlineCode),
                                        GLeaf.Generate(". Make sure you did not misspell it.")
                                    )
                                })
                            );
                            break;
                    }
                };
                // When client connects
                client.Connected += (o, e) => Console.WriteLine("I successfully logged in!");
                // Starts the bot
                MainAsync(client).GetAwaiter().GetResult();
            }
        }
        static async Task MainAsync(GuildedUserClient client) {
            // Connects to Guilded
            await client.ConnectAsync();
            // Makes it stop forever, so the bot wouldn't instantly shutdown after connecting.
            await Task.Delay(-1);
        }
    }
}
