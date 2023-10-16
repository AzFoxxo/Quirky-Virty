/*
 Copyright (c) 2023 Az Foxxo

 Permission is hereby granted, free of charge, to any person obtaining a copy of
 this software and associated documentation files (the "Software"), to deal in
 the Software without restriction, including without limitation the rights to
 use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
 the Software, and to permit persons to whom the Software is furnished to do so,
 subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

namespace Assembler
{
    struct Instruction
    {
        public Opcodes opcode { get; private set; }
        public bool flag { get; private set; }
        public bool lng { get; private set; }
        public string lngReg { get; private set; }

        public Instruction(Opcodes opcode, bool flag, bool lng, string lngReg)
        {
            this.opcode = opcode;
            this.flag = flag;
            this.lng = lng;
            this.lngReg = lngReg;
        }

        // Implicitly convert Instruction to List<Instruction> when needed
        public static implicit operator List<Instruction>(Instruction instruction)
        {
            return new List<Instruction> { instruction };
        }

        // Implicit to string conversion
        public static implicit operator string(Instruction instruction)
        {
            var op = OpcodesUtils.ToBinaryString(instruction.opcode);
            return $"{op} {instruction.opcode.ToString()} {instruction.flag} {instruction.lng} {instruction.lngReg} ";
        }
    }
}