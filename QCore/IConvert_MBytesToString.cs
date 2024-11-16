using System;
namespace QuickTools.QCore
{
    public partial class IConvert
    {
        /// <summary>
        /// Converts the text to an BytesSTring that 
        /// is mixed with it's caracters 
        /// </summary>
        /// <returns>The ytes to string.</returns>
        /// <param name="array">Array.</param>
        /// <param name="showDebuger">If set to <c>true</c> show debuger.</param>
        public static string MBytesToString(byte[] array, bool showDebuger)
        {
            return null;
        }

        static bool IsValidByte(byte b) => b >= 0 && b <= 124 ? true : false;

        static char GetCharacterForByte(byte value)
        {
            switch (value)
            {
                case 0: return 'A';
                case 1: return 'B';
                case 2: return 'C';
                case 3: return 'D';
                case 4: return 'E';
                case 5: return 'F';
                case 6: return 'G';
                case 7: return 'H';
                case 8: return 'I';
                case 9: return 'J';
                case 10: return 'K';
                case 11: return 'L';
                case 12: return 'M';
                case 13: return 'N';
                case 14: return 'O';
                case 15: return 'P';
                case 16: return 'Q';
                case 17: return 'R';
                case 18: return 'S';
                case 19: return 'T';
                case 20: return 'U';
                case 21: return 'V';
                case 22: return 'W';
                case 23: return 'X';
                case 24: return 'Y';
                case 25: return 'Z';
                case 26: return 'a';
                case 27: return 'b';
                case 28: return 'c';
                case 29: return 'd';
                case 30: return 'e';
                case 31: return 'f';
                case 32: return 'g';
                case 33: return 'h';
                case 34: return 'i';
                case 35: return 'j';
                case 36: return 'k';
                case 37: return 'l';
                case 38: return 'm';
                case 39: return 'n';
                case 40: return 'o';
                case 41: return 'p';
                case 42: return 'q';
                case 43: return 'r';
                case 44: return 's';
                case 45: return 't';
                case 46: return 'u';
                case 47: return 'v';
                case 48: return 'w';
                case 49: return 'x';
                case 50: return 'y';
                case 51: return 'z';
                case 52: return '0';
                case 53: return '1';
                case 54: return '2';
                case 55: return '3';
                case 56: return '4';
                case 57: return '5';
                case 58: return '6';
                case 59: return '7';
                case 60: return '8';
                case 61: return '9';
                case 62: return '!';
                case 63: return '@';
                case 64: return '#';
                case 65: return '$';
                case 66: return '%';
                case 67: return '^';
                case 68: return '&';
                case 69: return '*';
                case 70: return '(';
                case 71: return ')';
                case 72: return '-';
                case 73: return '_';
                case 74: return '=';
                case 75: return '+';
                case 76: return '{';
                case 77: return '}';
                case 78: return '[';
                case 79: return ']';
                case 80: return '|';
                case 81: return '\\';
                case 82: return ':';
                case 83: return ';';
                case 84: return '"';
                case 85: return '\'';
                case 86: return '<';
                case 87: return '>';
                case 88: return ',';
                case 89: return '.';
                case 90: return '?';
                case 91: return '/';
                case 92: return '`';
                case 93: return ' ';
                case 94: return '!';
                case 95: return '@';
                case 96: return '#';
                case 97: return '$';
                case 98: return '%';
                case 99: return '^';
                case 100: return '&';
                case 101: return '*';
                case 102: return '(';
                case 103: return ')';
                case 104: return '-';
                case 105: return '_';
                case 106: return '=';
                case 107: return '+';
                case 108: return '{';
                case 109: return '}';
                case 110: return '[';
                case 111: return ']';
                case 112: return '|';
                case 113: return '\\';
                case 114: return ':';
                case 115: return ';';
                case 116: return '"';
                case 117: return '\'';
                case 118: return '<';
                case 119: return '>';
                /*
                 * be caref ull with this one it could bite you
                 */
                case 120: return ',';
                case 121: return '.';
                case 122: return '?';
                case 123: return '/';
                case 124: return '`';
                default:
                    throw new InvalidCastException("There was a problem while trying to get the char representation for this character which is not supported");
                    /*
                case 125: return ' ';
                case 126: return ' ';
                case 127: return ' ';
                case 128: return ' ';
                case 129: return ' ';
                case 130: return ' ';
                case 131: return ' ';
                case 132: return ' ';
                case 133: return ' ';
                case 134: return ' ';
                case 135: return ' ';
                case 136: return ' ';
                case 137: return ' ';
                case 138: return ' ';
                case 139: return ' ';
                case 140: return ' ';
                case 141: return ' ';
                case 142: return ' ';
                case 143: return ' ';
                case 144: return ' ';
                case 145: return ' ';
                case 146: return ' ';
                case 147: return ' ';
                case 148: return ' ';
                case 149: return ' ';
                case 150: return ' ';
                case 151: return ' ';
                case 152: return ' ';
                case 153: return ' ';
                case 154: return ' ';
                case 155: return ' ';
                case 156: return ' ';
                case 157: return ' ';
                case 158: return ' ';
                case 159: return ' ';
                case 160: return ' ';
                case 161: return ' ';
                case 162: return ' ';
                case 163: return ' ';
                case 164: return ' ';
                case 165: return ' ';
                case 166: return ' ';
                case 167: return ' ';
                case 168: return ' ';
                case 169: return ' ';
                case 170: return ' ';
                case 171: return ' ';
                case 172: return ' ';
                case 173: return ' ';
                case 174: return ' ';
                case 175: return ' ';
                case 176: return ' ';
                case 177: return ' ';
                case 178: return ' ';
                case 179: return ' ';
                case 180: return ' ';
                case 181: return ' ';
                case 182: return ' ';
                case 183: return ' ';
                case 184: return ' ';
                case 185: return ' ';
                case 186: return ' ';
                case 187: return ' ';
                case 188: return ' ';
                case 189: return ' ';
                case 190: return ' ';
                case 191: return ' ';
                case 192: return ' ';
                case 193: return ' ';
                case 194: return ' ';
                case 195: return ' ';
                case 196: return ' ';
                case 197: return ' ';
                case 198: return ' ';
                case 199: return ' ';
                case 200: return ' ';
                case 201: return ' ';
                case 202: return ' ';
                case 203: return ' ';
                case 204: return ' ';
                case 205: return ' ';
                case 206: return ' ';
                case 207: return ' ';
                case 208: return ' ';
                case 209: return ' ';
                case 210: return ' ';
                case 211: return ' ';
                case 212: return ' ';
                case 213: return ' ';
                case 214: return ' ';
                case 215: return ' ';
                case 216: return ' ';
                case 217: return ' ';
                case 218: return ' ';
                case 219: return ' ';
                case 220: return ' ';
                case 221: return ' ';
                case 222: return ' ';
                case 223: return ' ';
                case 224: return ' ';
                case 225: return ' ';
                case 226: return ' ';
                case 227: return ' ';
                case 228: return ' ';
                case 229: return ' ';
                case 230: return ' ';
                case 231: return ' ';
                case 232: return ' ';
                case 233: return ' ';
                case 234: return ' ';
                case 235: return ' ';
                case 236: return ' ';
                case 237: return ' ';
                case 238: return ' ';
                case 239: return ' ';
                case 240: return ' ';
                case 241: return ' ';
                case 242: return ' ';
                case 243: return ' ';
                case 244: return ' ';
                case 245: return ' ';
                case 246: return ' ';
                case 247: return ' ';
                case 248: return ' ';
                case 249: return ' ';
                case 250: return ' ';
                case 251: return ' ';
                case 252: return ' ';
                case 253: return ' ';
                case 254: return ' ';
                case 255: return ' ';
                default: return '?';
                    */
            }
        }

    }
}
