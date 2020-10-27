using RestSharp;
using System.Net;
using System.Collections.Generic;
using System;

namespace Guilded.NET.Util {
    /// <summary>
    /// Utilities for Cookie related things.
    /// </summary>
    public static class CookieUtil {
        [Obsolete("RestResponseCookie is obsolete.")]
        /// <summary>
        /// Turns <see cref="RestResponseCookie"/> to <see cref="CookieContainer"/>.
        /// </summary>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static CookieContainer From(IEnumerable<RestResponseCookie> cookies) {
            // Init container
            CookieContainer container = new CookieContainer();
            // Add all cookies
            foreach(var cookie in cookies)
                container.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            // Return it
            return container;
        }
        [Obsolete("HttpCookie is obsolete.")]
        /// <summary>
        /// Turns <see cref="HttpCookie"/> to <see cref="CookieContainer"/>.
        /// </summary>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static CookieContainer From(IEnumerable<HttpCookie> cookies) {
            // Init container
            CookieContainer container = new CookieContainer();
            // Add all cookies
            foreach(var cookie in cookies)
                container.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            // Return it
            return container;
        }
    }
}