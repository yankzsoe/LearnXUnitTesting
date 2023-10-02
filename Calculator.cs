using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnXUnitTesting {
    public enum CalculatorState {
        Cleard = 0,
        Active = 1,
    }

    public class Calculator {
        private CalculatorState _state = CalculatorState.Cleard;
        public decimal Value { get; private set; }
        public decimal Add(decimal value) {
            _state = CalculatorState.Active;
            return Value += value;
        }
        public decimal Substract(decimal value) {
            _state = CalculatorState.Active;
            return Value -= value;
        }

        public decimal Multiply(decimal value) {
            if (Value == 0 && _state == CalculatorState.Cleard) {
                _state = CalculatorState.Active;
                return Value = value;
            }
            return Value *= value;
        }

        public decimal Divide(decimal value) {
            if (Value == 0 && _state == CalculatorState.Cleard) {
                _state = CalculatorState.Active;
                return Value = value;
            }
            return Value /= value;
        }
    }
}
