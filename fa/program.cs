using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    public class FA1
    {
        public State q0;
        public State q1;
        public State q2;
        public State q3;
        public State q4;
        public State q5;

        private State InitialState;

        public FA1()
        {
            q0 = new State()
            {
                Name = "q0",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q1 = new State()
            {
                Name = "q1",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q2 = new State()
            {
                Name = "q2",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q3 = new State()
            {
                Name = "q3",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };
            q4 = new State()
            {
                Name = "q4",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q5 = new State()
            {
                Name = "q5",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            InitialState = q0;

            q0.Transitions['0'] = q2;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q3;
            q1.Transitions['1'] = q1;

            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q3;

            q3.Transitions['0'] = q5;
            q3.Transitions['1'] = q3;

            q4.Transitions['0'] = q4;
            q4.Transitions['1'] = q5;

            q5.Transitions['0'] = q5;
            q5.Transitions['1'] = q5;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public State q00;
        public State q01;
        public State q10;
        public State q11;

        private State InitialState;

        public FA2()
        {
            q00 = new State()
            {
                Name = "q00",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q01 = new State()
            {
                Name = "q01",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q10 = new State()
            {
                Name = "q10",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q11 = new State()
            {
                Name = "q11",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            InitialState = q00;

            q00.Transitions['0'] = q10;
            q00.Transitions['1'] = q01;

            q01.Transitions['0'] = q11;
            q01.Transitions['1'] = q00;

            q10.Transitions['0'] = q00;
            q10.Transitions['1'] = q11;

            q11.Transitions['0'] = q01;
            q11.Transitions['1'] = q10;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public State q0;
        public State q1;
        public State q2;

        private State InitialState;

        public FA3()
        {
            q0 = new State()
            {
                Name = "q0",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q1 = new State()
            {
                Name = "q1",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            q2 = new State()
            {
                Name = "q2",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            InitialState = q0;

            q0.Transitions['0'] = q0;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q2;
            q2.Transitions['1'] = q2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
