using System.Collections.Generic;

namespace Models
{
    public static class Parameters
    {
        public static class GlobalParameters
        {

            /// <summary>
            /// on: smart LED is turned on / off: smart LED is turned off
            /// </summary>
            public const string Power = "power";
            /// <summary>
            /// The name of the device set by “set_name” command
            /// </summary>
            public const string Name = "name";
            /// <summary>
            /// 1: Music mode is on / 0: Music mode is off
            /// </summary>
            public const string Music = "music_on";
            /// <summary>
            /// Brightness of night mode light
            /// </summary>
            public const string NightModeBright = "nl_br";
            /// <summary>
            /// daylight mode / 1: moonlight mode (ceiling light only)
            /// </summary>
            public const string ActiveMode = "active_mode";
            public static IEnumerable<string> All = new List<string> { Power, Name, Music, NightModeBright, ActiveMode };
        }

        public static class FrontParameters
        {
            /// <summary>
            /// Brightness percentage. Range 1 ~ 100
            /// </summary>
            public const string Bright = "bright";
            /// <summary>
            /// Color temperature. Range 1700 ~ 6500(k)
            /// </summary>
            public const string ColorTemperature = "ct";
            /// <summary>
            /// Color. Range 1 ~ 16777215
            /// </summary>
            public const string Color = "rgb";
            /// <summary>
            /// Hue. Range 0 ~ 359
            /// </summary>
            public const string Hue = "hue";
            ///<sumary>
            /// Saturation. Range 0 ~ 100
            ///</summary>
            public const string Saturation = "sat";
            /// <summary>
            /// 1: rgb mode / 2: color temperature mode / 3: hsv mode
            /// </summary>
            public const string ColorMode = "color_mode";

            /// <summary>
            /// The remaining time of a sleep timer. Range 1 ~ 60 (minutes)
            /// </summary>
            public const string DelayOff = "delayoff";
            /// <summary>
            /// 0: no flow is running / 1:color flow is running
            /// </summary>
            public const string Flowing = "flowing";
            /// <summary>
            ///  Current flow parameters (only meaningful when 'flowing' is 1)
            /// </summary>
            public const string FlowParams = "flow_params";
            public static IEnumerable<string> All = new List<string> { Bright, Color, ColorMode, ColorTemperature, DelayOff, Flowing, FlowParams, Hue, Saturation };

        }
        public static class BackParameters
        {
            /// <summary>
            /// Background light power status
            /// </summary>
            public const string Power = "bg_power";
            /// <summary>
            /// 0: no flow is running / 1:color flow is running
            /// </summary>
            public const string Flowing = "bg_flowing";
            /// <summary>
            ///  Current flow parameters (only meaningful when 'flowing' is 1)
            /// </summary>
            public const string FlowParams = "bg_flow_params";

            /// <summary>
            /// Brightness percentage. Range 1 ~ 100
            /// </summary>
            public const string Bright = "bg_bright";
            /// <summary>
            /// Color temperature. Range 1700 ~ 6500(k)
            /// </summary>
            public const string ColorTemperature = "bg_ct";

            /// <summary>
            /// Color. Range 1 ~ 16777215
            /// </summary>
            public const string Color = "bg_rgb";
            /// <summary>
            /// Hue. Range 0 ~ 359
            /// </summary>
            public const string Hue = "bg_hue";
            ///<sumary>
            /// Saturation. Range 0 ~ 100
            ///</summary>
            public const string Saturation = "bg_sat";
            /// <summary>
            /// 1: rgb mode / 2: color temperature mode / 3: hsv mode
            /// </summary>
            public const string Mode = "bg_lmode";

            public static IEnumerable<string> All = new List<string> { Power, Bright, Color, ColorTemperature, Flowing, FlowParams, Hue, Mode, Power, Saturation };
        }

    }


}

