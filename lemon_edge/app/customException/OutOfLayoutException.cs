using System;
namespace app.CustomException;

public class OutOfLayoutException : Exception {


    public OutOfLayoutException() {
    }

    public OutOfLayoutException(string? message)
       : base(message) {


    }

    public OutOfLayoutException(string? message, Exception? innerException)
        : base(message, innerException) {

    }
}


