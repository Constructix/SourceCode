<Query Kind="Program" />

void Main()
{
	StateContext context = new StateContext();
	context.SetState(new LowerCaseState());
	context.WriteName("Richard");
}


public interface IState
{
	void WriteName(StateContext context, string name);
	
}

public class LowerCaseState : IState
{
	public void WriteName(StateContext context, string name)
	{	
		Console.WriteLine(name.ToLower());
		context.SetState(new UpperCaseState());
	}
}

public class UpperCaseState: IState
{
	public void WriteName(StateContext context, string name)
	{
		Console.WriteLine(name.ToUpper());
		context.SetState(new LowerCaseState());
	}
}

public class StateContext
{
	private IState state;
	
	public StateContext()
	{
		state =  new LowerCaseState();
	}
	
	public void SetState(IState newState)
	{		
		state = newState;
	}
	
	public void WriteName(string name)
	{
		state.WriteName(this,name);
	}
}