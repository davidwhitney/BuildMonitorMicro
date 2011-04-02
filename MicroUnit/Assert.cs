using System;
using MicroUnit.Exceptions;

namespace MicroUnit
{
    public static class Assert
    {
        public static void Pass(string message = null)
        {
            throw new AssertPassException(message);
        }

        public static void Ignore(string message = null)
        {
            throw new AssertIgnoreException(message);
        }

        public static void Inconclusive(string message = null)
        {
            throw new AssertInconclusiveException(message);
        }

        public static void Fail(string message = null)
        {
            throw new AssertFailException(message);
        }

        public static void True(bool @object)
        {
            if(!@object)
            {
                throw new AssertFailException("Assert True failed.");
            }
        }

        public delegate void AssertThrowsItemWhichReturnsVoid();
        public delegate object AssertThrowsItemWhichReturnsAnObject();

        public static Exception Throws(Type type, AssertThrowsItemWhichReturnsVoid methodWhichReturnsVoid)
        {
            try
            {
                methodWhichReturnsVoid();
            }
            catch(Exception ex)
            {
                if(ex.GetType() != type)
                {
                    Fail("Expected exception of type '" + type.FullName + "' however '" + ex.GetType().FullName + "' was thrown.");
                }

                return ex;
            }

            Fail("Expected exception of type '" + type.FullName + "'.");

            throw new InvalidOperationException("Code should have failed by this point.");
        }

        public static Exception Throws(Type type, AssertThrowsItemWhichReturnsAnObject methodWhichReturnsAnAnObject)
        {
            try
            {
                methodWhichReturnsAnAnObject();
            }
            catch(Exception ex)
            {
                if(ex.GetType() != type)
                {
                    Fail("Expected exception of type '" + type.FullName + "' however '" + ex.GetType().FullName + "' was thrown.");
                }

                return ex;
            }

            Fail("Expected exception of type '" + type.FullName + "'.");

            throw new InvalidOperationException("Code should have failed by this point.");
        }


        public static void That(string predicate, IsInstance.StringContainsContainerDelegate expectedToContainThisValue)
        {
            var delegateContainer = expectedToContainThisValue();
            var contains = delegateContainer.Is.StringContaining(predicate, delegateContainer.Value);

            if (contains) return;

            var message = delegateContainer.Is.Inverse ? "Expected string NOT containing" : "Expected string containing";
            message += " '" + delegateContainer.Value + "'.";

            Fail(message);
        }
    }
}