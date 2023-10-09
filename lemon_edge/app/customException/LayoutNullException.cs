
using System;
namespace app.CustomException;

public class LayoutNullException : Exception {

    public LayoutNullException() {
    }

    public LayoutNullException(string? message)
       : base(message) {


    }

    public LayoutNullException(string? message, Exception? innerException)
        : base(message, innerException) {

    }

}

