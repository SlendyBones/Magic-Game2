// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ForceFieldBlackHole"
{
	Properties
	{
		_Vector0("Vector 0", Vector) = (3,8,0,0)
		_Float1("Float 1", Float) = 1
		_Float2("Float 2", Float) = -1
		_Color0("Color 0", Color) = (0.8509804,0.7418529,0,0)
		_Float3("Float 3", Float) = 0
		_Float4("Float 4", Range( -20 , 20)) = 0
		_Float5("Float 5", Range( -10 , 10)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit alpha:fade keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
			float3 worldPos;
		};

		uniform float4 _Color0;
		uniform float _Float1;
		uniform float _Float2;
		uniform float2 _Vector0;
		uniform float _Float3;
		uniform float _Float4;
		uniform float _Float5;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			o.Emission = saturate( _Color0 ).rgb;
			float mulTime39 = _Time.y * _Float1;
			float2 temp_cast_1 = (_Float2).xx;
			float2 uv_TexCoord37 = i.uv_texcoord * _Vector0;
			float2 panner4 = ( mulTime39 * temp_cast_1 + uv_TexCoord37);
			float simplePerlin2D2 = snoise( panner4*_Float3 );
			simplePerlin2D2 = simplePerlin2D2*0.5 + 0.5;
			float Parte157 = step( simplePerlin2D2 , 0.24 );
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float4 transform50 = mul(unity_ObjectToWorld,float4( ase_vertex3Pos , 0.0 ));
			o.Alpha = ( Parte157 * saturate( ( ( transform50.y + _Float4 ) / _Float5 ) ) );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
507;73;887;617;589.9455;-79.31091;1;True;False
Node;AmplifyShaderEditor.Vector2Node;36;-1663.904,202.4889;Inherit;False;Property;_Vector0;Vector 0;0;0;Create;True;0;0;0;False;0;False;3,8;0.37,4.63;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;40;-1292.077,538.239;Inherit;False;Property;_Float1;Float 1;1;0;Create;True;0;0;0;False;0;False;1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;39;-1163.542,439.9958;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;41;-1211.3,359.7278;Inherit;False;Property;_Float2;Float 2;2;0;Create;True;0;0;0;False;0;False;-1;-2.69;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;37;-1282.073,97.1929;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;4;-943.8812,213.374;Inherit;True;3;0;FLOAT2;0,0;False;2;FLOAT2;-1,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;44;-802.5754,452.6177;Inherit;False;Property;_Float3;Float 3;4;0;Create;True;0;0;0;False;0;False;0;4;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;46;-672.3547,800.2743;Inherit;True;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;2;-626.056,207.0423;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;48;-287.0539,956.3145;Inherit;False;Property;_Float4;Float 4;5;0;Create;True;0;0;0;False;0;False;0;-0.5;-20;20;0;1;FLOAT;0
Node;AmplifyShaderEditor.ObjectToWorldTransfNode;50;-378.395,776.8173;Inherit;False;1;0;FLOAT4;0,0,0,1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;6;-371.8974,249.4964;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0.24;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;47;-153.8431,691.7544;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;54;34.05184,1068.085;Inherit;False;Property;_Float5;Float 5;6;0;Create;True;0;0;0;False;0;False;0;-1.4;-10;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;53;-21.60752,712.4838;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;57;-215.4404,168.6967;Inherit;False;Parte1;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;56;252.9721,531.9217;Inherit;True;57;Parte1;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;42;-416.615,-137.0992;Inherit;False;Property;_Color0;Color 0;3;0;Create;True;0;0;0;False;0;False;0.8509804,0.7418529,0,0;0,1,0.9907835,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;55;177.8385,744.952;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;43;-119.846,-24.83496;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;59;818.7112,647.9618;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;65.54332,101.8955;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;ForceFieldBlackHole;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;39;0;40;0
WireConnection;37;0;36;0
WireConnection;4;0;37;0
WireConnection;4;2;41;0
WireConnection;4;1;39;0
WireConnection;2;0;4;0
WireConnection;2;1;44;0
WireConnection;50;0;46;0
WireConnection;6;0;2;0
WireConnection;47;0;50;2
WireConnection;47;1;48;0
WireConnection;53;0;47;0
WireConnection;53;1;54;0
WireConnection;57;0;6;0
WireConnection;55;0;53;0
WireConnection;43;0;42;0
WireConnection;59;0;56;0
WireConnection;59;1;55;0
WireConnection;0;2;43;0
WireConnection;0;9;59;0
ASEEND*/
//CHKSM=FE7194EA82A84F2F170E651A565AADBB9848F552