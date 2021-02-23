Shader "Hidden/If"
{
    Properties
    {
        [HideInInspector] _MainTex ("Texture", 2D) = "white" {}
        _IfParam ("IfParam", Vector) = (1, 1, 1, 1)
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

            float4 _IfParam;
            fixed4 frag (const v2f i) : SV_Target
            {
                fixed4 col = (fixed4)0;
                if(_IfParam.x > 0.5)
                {
                    col.x = _IfParam.x;
                }
                if(_IfParam.y > 0.5)
                {
                    col.y = _IfParam.y;
                }
                if(_IfParam.z > 0.5)
                {
                    col.z = _IfParam.z;
                }
                if(_IfParam.w > 0.5)
                {
                    col.w = _IfParam.w;
                }
                return col;
            }
            ENDCG
        }
    }
}
