﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Utils;
using System.Globalization;

namespace Albatross.Expression.Operations {
	public class MonthName : PrefixOperationToken {

		public override string Name { get { return "MonthName"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = Operands.First().EvalValue(context);

			if (value == null) {
				return null;
			} else if (value is double) {
				return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(value));
			} else {
				throw new UnexpectedTypeException(value.GetType());
			}
		}
	}
}