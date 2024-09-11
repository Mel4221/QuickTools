//using System;
//using QuickTools.QCore;
//namespace QuickTools.QConsole
//{
//      /// <summary>
//      /// Creates an object handeler for the Input object
//      /// </summary>
//       class QInput
//      {

//            /// <summary>
//            /// Contains the ConsoleKeyInfo data 
//            /// </summary>
//            public class KeyInfo
//            {
//                  /// <summary>
//                  /// Gets or sets the key.
//                  /// </summary>
//                  /// <value>The key.</value>
//                  public object Key { get; set; }

//                  /// <summary>
//                  /// Gets or sets the key char.
//                  /// </summary>
//                  /// <value>The key char.</value>
//                  public object KeyChar { get; set; }

//                  /// <summary>
//                  /// Gets or sets the modifiers.
//                  /// </summary>
//                  /// <value>The modifiers.</value>
//                  public object Modifiers { get; set; }

//                  /// <summary>
//                  /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QInput.KeyInfo"/>.
//                  /// </summary>
//                  /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QInput.KeyInfo"/>.</returns>
//                  public override string ToString()
//                  {
//                        return $"Key: {this.Key} Char: {this.KeyChar} Modifier: {this.Modifiers}";
//                  }
//            }


//            /// <summary>
//            /// The default triger key.
//            /// </summary>
//            public string DefaultTrigerKey = "Escape";

//            /// <summary>
//            /// The label.
//            /// </summary>
//            public string Label = "Press Escape or Esc to exit";

//            /// <summary>
//            /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QInput"/> allow dislay label.
//            /// </summary>
//            /// <value><c>true</c> if allow dislay label; otherwise, <c>false</c>.</value>
//            public bool AllowDislayLabel { get; set; }

//            /// <summary>
//            /// The exit condition.
//            /// </summary>
//            public Func<KeyInfo, bool> ExitCondition;

//            /// <summary>
//            /// The display action.
//            /// </summary>
//            public Action<object> DisplayAction = (message) => { Get.Yellow(message); };

//            /// <summary>
//            /// The reading call back.
//            /// </summary>
//            public Func<KeyInfo, KeyInfo> ReadingCallBack = (item) => { return item; };


//            /// <summary>
//            /// Capture this instance.
//            /// </summary>
//            /// <returns>The capture.</returns>
//            public KeyInfo Capture()
//            {
//                  //Get.LabelSide("$");
//                  //Get.Reset();
//                  //Console.Write(" ");
//                  var obj = Console.ReadKey();

//                  return new KeyInfo()
//                  {         
//                        Key = obj.Key,
//                        KeyChar = obj.KeyChar,
//                        Modifiers = obj.Modifiers
//                  };
//            }


//            /// <summary>
//            /// Start this instance.
//            /// </summary>
//            public void Start()
//            {
//                  if (AllowDislayLabel) DisplayLabel();

//                  while (true)
//                  {
//                        var key = this.Capture();
//                        if (ExitCondition(key))
//                        {
//                              break;
//                        }
//                        else
//                        {
//                              this.ReadingCallBack(key);
//                        }
//                  }
//            }


//            /// <summary>
//            /// Contains the method which handles the display mecanisim 
//            /// </summary>
//            public virtual void DisplayLabel() => DisplayAction(this.Label);


//            /// <summary>
//            /// Initializes a new instance of the <see cref="T:QuickTools.QInput"/> class.
//            /// </summary>
//            public QInput()
//            {
//                  this.ExitCondition = (triger) =>
//                  {
//                        if (triger.Key.ToString() == this.DefaultTrigerKey)
//                        {
//                              return true;
//                        }
//                        if (triger.KeyChar.ToString() == this.DefaultTrigerKey)
//                        {
//                              return true;
//                        }
//                        if (triger.Modifiers.ToString() == this.DefaultTrigerKey)
//                        {
//                              return true;
//                        }
//                        else
//                        {
//                              return false;
//                        }
//                  };
//            }
//      }
//}