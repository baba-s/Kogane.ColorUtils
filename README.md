# Uni Color Utils

Color 型と16進数、HTML カラー形式の文字列の変換ができる機能

## 使用例

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        // RGBA(1.000, 0.502, 0.000, 1.000)
        Debug.Log( ColorUtils.FromRGB( 255, 128, 0 ) );

        // RGBA(1.000, 0.502, 0.000, 1.000)
        Debug.Log( ColorUtils.FromRGBA( 255, 128, 0, 255 ) );

        // RGBA(1.000, 0.502, 0.000, 1.000)
        Debug.Log( ColorUtils.FromARGB( 255, 255, 128, 0 ) );
        
        // RGBA(1.000, 0.502, 0.000, 1.000)
        Debug.Log( ColorUtils.FromRGB( 0xFF8000 ) );
        
        // RGBA(1.000, 0.502, 0.000, 1.000)
        Debug.Log( ColorUtils.FromRGBA( 0xFF8000FF ) );
        
        // RGBA(1.000, 0.502, 0.000, 1.000)
        Debug.Log( ColorUtils.FromARGB( 0xFFFF8000 ) );
        
        // RGBA(1.000, 0.502, 0.000, 1.000)
        Debug.Log( ColorUtils.FromRGB( "#FF8000" ) );
        
        // RGBA(1.000, 0.502, 0.000, 1.000)
        Debug.Log( ColorUtils.FromRGBA( "#FF8000FF" ) );

        // ff0000
        Debug.Log( ColorUtils.ToRGBHtmlStringLower( Color.red ) );

        // ff0000ff
        Debug.Log( ColorUtils.ToRGBAHtmlStringLower( Color.red ) );

        // fff0000
        Debug.Log( ColorUtils.ToARGBHtmlStringLower( Color.red ) );

        // FF0000
        Debug.Log( ColorUtils.ToRGBHtmlStringUpper( Color.red ) );

        // FF0000FF
        Debug.Log( ColorUtils.ToRGBAHtmlStringUpper( Color.red ) );

        // FFFF0000
        Debug.Log( ColorUtils.ToARGBHtmlStringUpper( Color.red ) );
    }
}
```
