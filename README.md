# Quirky Virty (QKVT) 8 bit simplifed architecture
Quirky Virty is a highly simplified 8 bit virutal machine with a reduced instruction set using a console interface which loads roms.

## CPU
The CPU operates at 2MHz (single threaded) and each instruction takes one whole byte, the first bit is the flag which can either be `0` or `1` - one being alternate behaviour, the second bit contains whether an additional eight bits is required for the instruction `1` or if the instruction requires no other space `0`. This leaves 6 bits for the instruction itself.

## Memory layout
The memory is split into several parts, in total, there is 256 addressable locations in each memory bank.

### Memory banks
- `BANK_A` - The A bank is used to store program ROM
- `BANK_B` - The B bank is free memory bank you can write and read to freely

#### Bank A
Bank A is reservsed for ROM, it cannot be written to directly or read for security reasons. The last byte is automatically set to `HLT` instruction even if ROM cannot fit with this change.

#### Bank B and general purpose banks
Bank B is the general purpose memory bank. Addressable locations from 0 to 247 may be used for anything you want. The last eight addressable spaces are reserved for devices. The lower four addressable locations contain memory bank information which is read only with the upper four containing device information (if supported device is plugged in).
This means that four total memory banks can be used in theory however two is the default configuration and as such, `BNK`, should not have a use but is more to future proof the machine if 2 banks proves insufficient.

Memory banks are stored in memory as follows:
- `BANK_A` is stored `0000 1001` if accessible (required) else `0000 0001` (impossible)
- `BANK_B` is stored `0000 1010` if accessible (required) else `0000 0010` (impossible)
- `BANK_C` is stored `0000 1011` if accessible else `0000 0011`
- `BANK_D` is stored `0000 1100` if accessible else `0000 0100`

The first four bits should never be used.


## Registers
- `A` register is the first regiser which instructions can use. It can be read and data loaded into
- `B` register is the second regiser which instructions can use. It can be read and data loaded into
- `C` register is the results register. It can be read but not written to
- `P` register is the program pointer. It is read only and points to the current instruction being executed in memory in `BANK_A` ROM.
- `M` - is the memory bank register which points to the current memory bank being addressed

## Instruction set
The according order below, shows the binary form of each instruction so `LDA` would be `--00 0000` (first two bits reversed for flag and if it requires additional space after)
- `LDA` `&memory_address` - Load value from memory into A register
- `LDB` `&memory_address` - Load value from memory into B register
- `STA` `&memory_address` - Store the value at A to memory
- `STB` `&memory_address` - Store the value at B to memory
- `STC` `&memory_address` - Store the value at C to memory
- `ADD` - Adds the value of the A register and B register and stores the result in the C register
- `SUB` - Subtracts the value of the A register and B register and stores the result in the C register
- `JMP` `&memory_address` - Move the program pointer to a new memory address
- `JNZ` `&memory_address` - Move the program pointer to a new memory address if C register is not zero
- `JZ` `&memory_address` - Move the program pointer to a new memory address if C register is zero
- `NOP` - Skip cycle and perform no instruction
- `SET` `flag` `&memory_address` `constant` - Set an address in memory to the value of the A reister if no flag set, else read the 1 byte after as data (`SET` with an address and flag is transformed `LDACON constant` and then `STA &memory_address` as `SET` does the same to `STA`)
- `CMP` `flag` - Compares the values in register A and B and stores the result in the C register (if flag is 0 - no flip, if not zero, flip output stored in the C register)
- `CPL` `flag` - Compares if value in A register is less than B register and stores result in C (if flag is 0 - no flip, if not zero, flip output stored in the C register)
- `AND` (Bitwise AND): Performs a bitwise AND operation between the values in registers A and B and stores the result in the A register.
- `OR` (Bitwise OR): Performs a bitwise OR operation between the values in registers A and B and stores the result in the A register.
- `XOR` (Bitwise XOR): Performs a bitwise XOR operation between the values in registers A and B and stores the result in the A register.
- `HLT` - Halt execution of the machine (kill the interpreter/shutdown)
- `BNK` `&memory_address` - Switch memory banks (where A and B read/write to (does not effect P register or C register))
- `LDACON` `value`- Load a constant into A register (this cannot be invoked, it is a sub-instruction called by `SET` when setting memory to a constant)