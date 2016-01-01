// ***********************************************************************
// Assembly         : ConsoleWebServer.Framework
// Author           : Batman
// Created          : 10-15-2015
//
// Last Modified By : Robin
// Last Modified On : 10-15-2015
// ***********************************************************************
// <copyright file="IResponseProvider.cs" company="TheDarkKnightCorp">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ConsoleWebServer.Framework.Contracts
{
    using HttpServerLogic;

    /// <summary>
    /// Interface IResponseProvider which contains a method that returns a server response content.
    /// </summary>
    public interface IResponseProvider
    {
        /// <summary>
        /// Gets the response from the server.
        /// Takes only one parameter of type string.
        /// </summary>
        /// <param name="requestAsString">The request as string.</param>
        /// <returns>HttpResponse.</returns>
        HttpResponse GetResponse(string requestAsString);
    }
}