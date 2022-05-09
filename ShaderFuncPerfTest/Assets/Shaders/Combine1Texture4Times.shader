Shader "Hidden/Combine1Texture4Times"
{
    Properties
    {
        _Tex1 ("Texture", 2D) = "black" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _Tex1;

            fixed4 frag (const v2f i) : SV_Target
            {
                const float2 uv = i.uv * 0.5;
                return tex2D(_Tex1, uv) + tex2D(_Tex1, uv + float2(0.5, 0)) + tex2D(_Tex1, uv + float2(0, 0.5)) + tex2D(_Tex1, uv + float2(0, 0.5));
            }
            ENDCG
        }
    }
}
