﻿namespace ConsoleWebServer.Framework.HttpServerLogic
{
    using System.Linq;
    using System.Reflection;

    using Contracts;

    using CustomExceptions;

    public class ActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            /*
         * Child processes that use such C run-time functions as printf() and fprintf() can behave poorly when redirected.
         * The C run-time functions maintain separate IO buffers. When redirected, these buffers might not be flushed immediately after each IO call.
         * As a result, the output to the redirection pipe of a printf() call or the input from a getch() call is not flushed immediately and delays, sometimes-infinite delays occur.
         * This problem is avoided if the child process flushes the IO buffers after each call to a C run-time IO function.
         * Only the child process can flush its C run-time IO buffers. A process can flush its C run-time IO buffers by calling the fflush() function.
         */
            var methodWithIntParameter = controller.GetType()
                                          .GetMethods()
                                          .FirstOrDefault(x => x.Name.ToLower() == actionDescriptor.ActionName.ToLower() &&
                                                               x.GetParameters().Length == 1 &&
                                                               x.GetParameters()[0].ParameterType == typeof(string) &&
                                                               x.ReturnType == typeof(IActionResult));
            if (methodWithIntParameter == null)
            {
                throw new HttpNotFoundException(
                    string.Format(
                        "Expected method with signature IActionResult {0}(string) in class {1}Controller",
                        actionDescriptor.ActionName,
                        actionDescriptor.ControllerName));
            }

            try
            {
                var actionResult = (IActionResult)
                    methodWithIntParameter.Invoke(controller, new object[] { actionDescriptor.Parameter });
                return actionResult;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}