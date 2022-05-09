Shader "Hidden/Combine4Texture"
{
    Properties
    {
        _Tex1 ("Texture", 2D) = "black" {}
        _Tex2 ("Texture", 2D) = "black" {}
        _Tex3 ("Texture", 2D) = "black" {}
        _Tex4 ("Texture", 2D) = "black" {}
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
            sampler2D _Tex2;
            sampler2D _Tex3;
            sampler2D _Tex4;

            fixed4 frag (const v2f i) : SV_Target
            {
                return tex2D(_Tex1, i.uv) + tex2D(_Tex2, i.uv) + tex2D(_Tex3, i.uv) + tex2D(_Tex4, i.uv);
            }
            ENDCG
        }
    }
}
