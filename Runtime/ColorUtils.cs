// 以下の警告を無効化
// warning CS0675: Bitwise-or operator used on a sign-extended operand; consider casting to a smaller unsigned type first

#pragma warning disable 0675

using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// 色の変換を行うクラス
    /// </summary>
    public static class ColorUtils
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// <para>各色成分を 0 から 255 の範囲で指定して Color 型のインスタンスを作成します</para>
        /// <para>アルファ値は 255 が自動で設定されます</para>
        /// </summary>
        public static Color FromRGB( byte r, byte g, byte b )
        {
            return new( r / 255f, g / 255f, b / 255f );
        }

        /// <summary>
        /// 各色成分を 0 から 255 の範囲で指定して Color 型のインスタンスを作成します
        /// </summary>
        public static Color FromRGBA( byte r, byte g, byte b, byte a )
        {
            return new( r / 255f, g / 255f, b / 255f, a / 255f );
        }

        /// <summary>
        /// 各色成分を 0 から 255 の範囲で指定して Color 型のインスタンスを作成します
        /// </summary>
        public static Color FromARGB( byte a, byte r, byte g, byte b )
        {
            return new( r / 255f, g / 255f, b / 255f, a / 255f );
        }

        /// <summary>
        /// <para>16 進数の数値から Color 型のインスタンスを作成します</para>
        /// <para>ColorUtils.FromRGB( 0xFF8000 ) -> // RGBA( 1.0, 0.5, 0.0, 1.0 )</para>
        /// </summary>
        public static Color FromRGB( long value )
        {
            var inv   = 1f / 255f;
            var color = Color.black;
            color.r = inv * ( ( value >> 16 ) & 0xFF );
            color.g = inv * ( ( value >> 8 ) & 0xFF );
            color.b = inv * ( value & 0xFF );
            color.a = 1f;
            return color;
        }

        /// <summary>
        /// <para>16 進数の数値から Color 型のインスタンスを作成します</para>
        /// <para>ColorUtils.FromRGBA( 0xFF8000FF ) -> // RGBA( 1.0, 0.5, 0.0, 1.0 )</para>
        /// </summary>
        public static Color FromRGBA( long value )
        {
            var inv   = 1f / 255f;
            var color = Color.black;
            color.r = inv * ( ( value >> 24 ) & 0xFF );
            color.g = inv * ( ( value >> 16 ) & 0xFF );
            color.b = inv * ( ( value >> 8 ) & 0xFF );
            color.a = inv * ( value & 0xFF );
            return color;
        }

        /// <summary>
        /// <para>16 進数の数値から Color 型のインスタンスを作成します</para>
        /// <para>ColorUtils.FromARGB( 0xFFFF8000 ) -> // RGBA( 1.0, 0.5, 0.0, 1.0 )</para>
        /// </summary>
        public static Color FromARGB( long value )
        {
            var inv   = 1f / 255f;
            var color = Color.black;
            color.a = inv * ( ( value >> 24 ) & 0xFF );
            color.r = inv * ( ( value >> 16 ) & 0xFF );
            color.g = inv * ( ( value >> 8 ) & 0xFF );
            color.b = inv * ( value & 0xFF );
            return color;
        }

        /// <summary>
        /// <para>16 進数を表す文字列から Color 型のインスタンスを作成します</para>
        /// <para>ColorUtils.FromRGB( "#FF8000" ) -> // RGBA( 1.0, 0.5, 0.0, 1.0 )</para>
        /// </summary>
        public static Color FromRGB( string htmlString )
        {
            ColorUtility.TryParseHtmlString( htmlString, out var color );
            return color;
        }

        /// <summary>
        /// <para>16 進数を表す文字列から Color 型のインスタンスを作成します</para>
        /// <para>ColorUtils.FromRGBA( "#FF8000FF" ) -> // RGBA( 1.0, 0.5, 0.0, 1.0 )</para>
        /// </summary>
        public static Color FromRGBA( string htmlString )
        {
            ColorUtility.TryParseHtmlString( htmlString, out var color );
            return color;
        }

        /// <summary>
        /// 16 進数の数値に変換します
        /// </summary>
        public static long ToRGB( Color color )
        {
            long value = 0;
            value |= ( long )Mathf.RoundToInt( color.r * 255 ) << 16;
            value |= ( long )Mathf.RoundToInt( color.g * 255 ) << 8;
            value |= Mathf.RoundToInt( color.b * 255 );
            return value;
        }

        /// <summary>
        /// 16 進数の数値に変換します
        /// </summary>
        public static long ToRGBA( Color color )
        {
            long value = 0;
            value |= ( long )Mathf.RoundToInt( color.r * 255 ) << 24;
            value |= ( long )Mathf.RoundToInt( color.g * 255 ) << 16;
            value |= ( long )Mathf.RoundToInt( color.b * 255 ) << 8;
            value |= Mathf.RoundToInt( color.a * 255 );
            return value;
        }

        /// <summary>
        /// 16 進数の数値に変換します
        /// </summary>
        public static long ToARGB( Color color )
        {
            long value = 0;
            value |= ( long )Mathf.RoundToInt( color.a * 255 ) << 24;
            value |= ( long )Mathf.RoundToInt( color.r * 255 ) << 16;
            value |= ( long )Mathf.RoundToInt( color.g * 255 ) << 8;
            value |= Mathf.RoundToInt( color.b * 255 );
            return value;
        }

        /// <summary>
        /// <para>16 進数を表す数値に変換します</para>
        /// <para>ColorUtils.ToRGBHtmlStringLower( Color.red ) -> // ff0000</para>
        /// </summary>
        public static string ToRGBHtmlStringLower( Color color )
        {
            return ToRGB( color ).ToString( "x6" );
        }

        /// <summary>
        /// <para>16 進数を表す数値に変換します</para>
        /// <para>ColorUtils.ToRGBAHtmlStringLower( Color.red ) -> // ff0000ff</para>
        /// </summary>
        public static string ToRGBAHtmlStringLower( Color color )
        {
            return ToRGBA( color ).ToString( "x8" );
        }

        /// <summary>
        /// <para>16 進数を表す数値に変換します</para>
        /// <para>ColorUtils.ToARGBHtmlStringLower( Color.red ) -> // ffff0000</para>
        /// </summary>
        public static string ToARGBHtmlStringLower( Color color )
        {
            return ToARGB( color ).ToString( "x8" );
        }

        /// <summary>
        /// <para>16 進数を表す数値に変換します</para>
        /// <para>ColorUtils.ToRGBHtmlStringUpper( Color.red ) -> // FF0000</para>
        /// </summary>
        public static string ToRGBHtmlStringUpper( Color color )
        {
            return ToRGB( color ).ToString( "X6" );
        }

        /// <summary>
        /// <para>16 進数を表す数値に変換します</para>
        /// <para>ColorUtils.ToRGBAHtmlStringUpper( Color.red ) -> // FF0000FF</para>
        /// </summary>
        public static string ToRGBAHtmlStringUpper( Color color )
        {
            return ToRGBA( color ).ToString( "X8" );
        }

        /// <summary>
        /// <para>16 進数を表す数値に変換します</para>
        /// <para>ColorUtils.ToARGBHtmlStringUpper( Color.red ) -> // FFFF0000</para>
        /// </summary>
        public static string ToARGBHtmlStringUpper( Color color )
        {
            return ToARGB( color ).ToString( "X8" );
        }

        /// <summary>
        /// アルファブレンドした色を返します
        /// </summary>
        public static Color AlphaBlend
        (
            in Color backgroundColor,
            in Color overlapColor,
            float    alpha
        )
        {
            return backgroundColor + ( overlapColor - backgroundColor ) * alpha;
        }
    }
}