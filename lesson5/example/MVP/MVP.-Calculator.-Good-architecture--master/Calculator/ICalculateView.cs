using System;

namespace Calculator
{
    public interface ICalculateView
    {
        string Operand1 { get; set; }
        string Operand2 { get; set; }
        string Operation { get; }
        string Result { get; set; }
        event EventHandler<EventArgs> CalculateEvent;
    }
}
