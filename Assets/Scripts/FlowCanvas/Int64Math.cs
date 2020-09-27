using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ParadoxNotion.Design;
using UnityEngine;

namespace FlowCanvas.Nodes{
    
	////////////////////////////////////////
	///////////////LONG//////////////////
	////////////////////////////////////////

	[Category("Functions/Math/Longs")]
	[Name("+")]
	public class LongAdd : PureFunctionNode<long, long, long>{
		public override long Invoke(long a, long b){
			return a + b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("-")]
	public class LongSubtract : PureFunctionNode<long, long, long>{
		public override long Invoke(long a, long b){
			return a - b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("*")]
	public class LongMultiply : PureFunctionNode<long, long, long>{
		public override long Invoke(long a, long b){
			return a * b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("÷")]
	public class LongDivide : PureFunctionNode<long, long, long>{
		public override long Invoke(long a, long b){
			return b == 0? 0 : a / b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("%")]
	public class LongModulo : PureFunctionNode<long, long, long>{
		public override long Invoke(long value, long mod){
			return value % mod;
		}
	}


	[Category("Functions/Math/Longs")]
	[Name(">")]
	public class LongGreaterThan : PureFunctionNode<bool, long, long>{
		public override bool Invoke(long a, long b){
			return a > b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name(">=")]
	public class LongGreaterEqualThan : PureFunctionNode<bool, long, long>{
		public override bool Invoke(long a, long b){
			return a >= b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("<")]
	public class LongLessThan : PureFunctionNode<bool, long, long>{
		public override bool Invoke(long a, long b){
			return a < b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("<=")]
	public class LongLessEqualThan : PureFunctionNode<bool, long, long>{
		public override bool Invoke(long a, long b){
			return a <= b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("==")]
	public class LongEqual : PureFunctionNode<bool, long, long>{
		public override bool Invoke(long a, long b){
			return a == b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("!=")]
	public class LongNotEqual : PureFunctionNode<bool, long, long>{
		public override bool Invoke(long a, long b){
			return a != b;
		}
	}

	[Category("Functions/Math/Longs")]
	[Name("Invert")]
	public class LongInvert : PureFunctionNode<long, long>{
		public override long Invoke(long value){
			return value * -1;
		}
	}
}