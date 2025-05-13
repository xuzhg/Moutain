using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DfaTest;

internal static class DfaMatcher
{
    private static ISet<State> _acceptStates = new HashSet<State> { State.Q2, State.Q4 };

    enum State
    {
        Q0,
        Q1,
        Q2,
        Q3,
        Q4,
        Q5,
        Reject
    }

    private static State DoTransition(State currentState, char input)
    {
        switch (currentState)
        {
            case State.Q0:
                if (input == '-')
                {
                    return State.Q1;
                }
                if (input >= '0' && input <= '9')
                {
                    return State.Q2;
                }
                break;
            case State.Q1:
                if (input >= '0' && input <= '9')
                {
                    return State.Q2;
                }
                break;
            case State.Q2:
                if (input >= '0' && input <= '9')
                {
                    return State.Q2;
                }
                else if (input == '.')
                {
                    return State.Q3;
                }
                break;
            case State.Q3:
                if (input >= '0' && input <= '9')
                {
                    return State.Q4;
                }
                break;
            case State.Q4:
                if (input >= '0' && input <= '9')
                {
                    return State.Q4;
                }
                break;
        }

        return State.Reject;
    }

    public static bool IsMatch(string input)
    {
        State currentState = State.Q0;

        foreach (char inputChar in input)
        {
            currentState = DoTransition(currentState, inputChar);
            if (currentState == State.Reject)
            {
                return false;
            }
        }

        return _acceptStates.Contains(currentState);
    }
}
