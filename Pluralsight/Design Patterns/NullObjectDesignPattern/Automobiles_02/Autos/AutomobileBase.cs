using System;

namespace Automobiles_02
{
    public abstract class AutomobileBase
    {
        public abstract  Guid Id { get; }
        public abstract string Name { get; }
        public abstract void Start();
        public abstract void Stop();


        #region Null
        
        static readonly NullAutomobile nullAutomobile  = new NullAutomobile();

        public static NullAutomobile Null
        {
            get { return nullAutomobile; }
        }

        public class NullAutomobile : AutomobileBase
        {
            public override Guid Id { get {return Guid.Empty;} }
            public override string Name { get { return string.Empty; } }
            public override void Start()
            {
                
            }

            public override void Stop()
            {
                
            }
        }

        #endregion  
    }



}