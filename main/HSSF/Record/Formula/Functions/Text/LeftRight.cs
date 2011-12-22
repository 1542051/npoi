/*
* Licensed to the Apache Software Foundation (ASF) Under one or more
* contributor license agreements.  See the NOTICE file distributed with
* this work for Additional information regarding copyright ownership.
* The ASF licenses this file to You Under the Apache License, Version 2.0
* (the "License"); you may not use this file except in compliance with
* the License.  You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed Under the License is distributed on an "AS Is" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations Under the License.
*/
/*
 * Created on May 15, 2005
 *
 */
namespace NPOI.SS.Formula.Functions
{
    using System;
    using NPOI.SS.Formula.Eval;

    /**
     * @author Amol S. Deshmukh &lt; amolweb at ya hoo dot com &gt;
     *
     */
    public class LeftRight : TextFunction
    {

        private bool _isLeft;
        public LeftRight(bool isLeft)
        {
            _isLeft = isLeft;
        }
        public override ValueEval EvaluateFunc(ValueEval[] args, int srcCellRow, int srcCellCol)
        {
            if (args.Length != 2)
            {
                return ErrorEval.VALUE_INVALID;
            }
            String arg = EvaluateStringArg(args[0], srcCellRow, srcCellCol);
            int index = EvaluateIntArg(args[1], srcCellRow, srcCellCol);

            String result;
            if (_isLeft)
            {
                result = arg.Substring(0, Math.Min(arg.Length, index));
            }
            else
            {
                result = arg.Substring(Math.Max(0, arg.Length - index));
            }
            return new StringEval(result);
        }
    }
}