using QuickTools.QCore;

namespace QuickTools.QConsole.Emulation
{
    public partial class QVim
    {

        /// <summary>
        /// provides the check to validate if the current key precess is an arrow key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HasArrows(KeyInfo key)
        {
            string input = key.Key;
            bool has = false;
            switch (input)
            {
                case "LeftArrow":
                case "RightArrow":
                case "UpArrow":
                case "DownArrow":
                    has = true;
                    break;
            }
            return has;
        }

        public bool HasShift(KeyInfo key)
        {
            if (key.Modifiers == "Shift")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasShiftAndControl(KeyInfo key)
        {
            bool hasBoth = false;
            if (key.Modifiers.Contains(","))
            {
                hasBoth = true;
            }

            return hasBoth;

        }

        public bool HasControl(KeyInfo key)
        {
            bool hasControl = false;
            if (key.Modifiers == "Control")
            {
                hasControl = true;
            }
            return hasControl;
        }

        public bool HasSimbol(KeyInfo key)
        {
            char input = key.KeyChar;
            if (Get.IsNumber(input))
            {
                return false;
            }
            foreach (char ch in IRandom.LowerCase)
            {
                if (input == ch)
                {
                    return false;
                }
            }
            foreach (char ch in IRandom.UpperCase)
            {
                if (input == ch)
                {
                    return false;
                }
            }
            return true;
        }

        public bool HasCommand(KeyInfo key)
        {
            bool isCommand = true;
            string input = key.Key;
            switch (input)
            {
                case "Escape":
                case "Tab":
                case "Spacebar":
                case "Backspace":
                case "Delete":
                case "Insert":
                case "Enter":
                    break;
                default:
                    isCommand = false;
                    break;
            }


            return isCommand;
        }
    }
}
