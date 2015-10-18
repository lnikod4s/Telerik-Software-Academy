// ***********************************************************************
// Assembly         : ConsoleWebServer.Framework
// Author           : Batman
// Created          : 10-15-2015
//
// Last Modified By : Robin
// Last Modified On : 10-15-2015
// ***********************************************************************
// <copyright file="IActionResult.cs" company="TheDarkKnightCorp">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ConsoleWebServer.Framework.Contracts
{
    using HttpServerLogic;

    /// <summary>
    /// Interface IActionResult which contains a method that returns server response content.
    /// </summary>
    public interface IActionResult
    {
        /// <summary>
        /// Gets the response from the server.
        /// Takes no parameters.
        /// </summary>
        /// <returns>HttpResponse.</returns>
        HttpResponse GetResponse();
    }
}