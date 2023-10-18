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

using QKVTShared;

namespace Assembler
{
    public static class OpcodesUtils
    {
        /// <summary>
        /// Convert opcode to binary representation.
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public static string ToBinaryString(this Opcodes opcode)
        {
            return Convert.ToString((int)opcode, 2).PadLeft(6, '0');
        }

        public static int ToSixBitBinary(this Opcodes opcode)
        {
            return (int)opcode & 0b001111; // Masking to get only the 6 least significant bits
        }
    }
}