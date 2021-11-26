// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Portal"
{
	Properties
	{
		_EdgeLength ( "Edge length", Range( 2, 50 ) ) = 15
		_MainTexture("Main Texture", 2D) = "white" {}
		[HDR]_MainColor("Main Color", Color) = (0,0,0,0)
		_Float0("Float 0", Float) = 0
		_Vector0("Vector 0", Vector) = (0.5,0.5,0,0)
		_Distance("Distance", Vector) = (0.5,0.56,0,0)
		_Mul("Mul", Float) = 0
		_Alpha("Alpha", Float) = 0
		_Scale("Scale", Float) = 0
		[HDR]_SecondaryColor("SecondaryColor", Color) = (0,0,0,0)
		_RenderTexture("Render Texture", 2D) = "white" {}
		_Flowmap("Flowmap", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "Tessellation.cginc"
		#pragma target 4.6
		#pragma surface surf Standard keepalpha noshadow exclude_path:deferred vertex:vertexDataFunc tessellate:tessFunction 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _RenderTexture;
		uniform sampler2D _Flowmap;
		uniform float _Alpha;
		uniform float4 _MainColor;
		uniform float4 _SecondaryColor;
		uniform sampler2D _MainTexture;
		uniform float2 _Vector0;
		uniform float _Float0;
		uniform float _Scale;
		uniform float2 _Distance;
		uniform float _Mul;
		uniform float _EdgeLength;

		float4 tessFunction( appdata_full v0, appdata_full v1, appdata_full v2 )
		{
			return UnityEdgeLengthBasedTess (v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
		}

		void vertexDataFunc( inout appdata_full v )
		{
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 panner200 = ( _Time.y * float2( 0.05,0.05 ) + i.uv_texcoord);
			float4 appendResult177 = (float4(tex2D( _Flowmap, panner200 )));
			float4 lerpResult178 = lerp( float4( i.uv_texcoord, 0.0 , 0.0 ) , appendResult177 , _Alpha);
			float4 lerpResult238 = lerp( tex2D( _RenderTexture, lerpResult178.xy ) , tex2D( _RenderTexture, lerpResult178.xy ) , float4( 0,0,0,0 ));
			o.Albedo = lerpResult238.rgb;
			float4 lerpResult143 = lerp( saturate( _MainColor ) , saturate( _SecondaryColor ) , _SinTime.z);
			float mulTime130 = _Time.y * _Float0;
			float cos64 = cos( mulTime130 );
			float sin64 = sin( mulTime130 );
			float2 rotator64 = mul( i.uv_texcoord - _Vector0 , float2x2( cos64 , -sin64 , sin64 , cos64 )) + _Vector0;
			float4 temp_output_221_0 = ( tex2D( _MainTexture, rotator64 ) + -_Scale );
			o.Emission = saturate( ( saturate( lerpResult143 ) * saturate( temp_output_221_0 ) ) ).rgb;
			o.Alpha = saturate( ( step( ( distance( i.uv_texcoord , _Distance ) * _Mul ) , 0.35 ) + temp_output_221_0 ) ).r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
507;73;887;617;1604.687;-10.73926;2.93177;True;False
Node;AmplifyShaderEditor.CommentaryNode;134;-1769.181,1205.022;Inherit;False;1071.995;657.5131;Parte circulito Rotar;7;129;77;130;131;132;1;222;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;129;-1649.343,1747.535;Inherit;False;Property;_Float0;Float 0;8;0;Create;True;0;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;228;-2933.061,-351.5176;Inherit;False;Constant;_Vector1;Vector 1;16;0;Create;True;0;0;0;False;0;False;0.05,0.05;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;201;-2856.2,-163.3953;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;77;-1360.877,1334.071;Inherit;False;263;206;Permite rotar el UV;1;64;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;176;-2914.104,-760.4478;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;132;-1666.945,1255.022;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;131;-1719.181,1545.185;Inherit;False;Property;_Vector0;Vector 0;9;0;Create;True;0;0;0;False;0;False;0.5,0.5;0.5,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;130;-1458.354,1661.736;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-893.0976,610.0688;Inherit;False;Property;_MainColor;Main Color;7;1;[HDR];Create;True;0;0;0;False;0;False;0,0,0,0;0,0.9005235,2,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RotatorNode;64;-1319.912,1382.119;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;0.1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ColorNode;119;-914.3412,780.952;Inherit;False;Property;_SecondaryColor;SecondaryColor;14;1;[HDR];Create;True;0;0;0;False;0;False;0,0,0,0;0.2636805,2.009493,3.726685,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;222;-896.613,1614.537;Inherit;False;Property;_Scale;Scale;13;0;Create;True;0;0;0;False;0;False;0;0.27;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;200;-2647.537,-312.5023;Inherit;True;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;151;-789.5416,299.375;Inherit;False;Property;_Distance;Distance;10;0;Create;True;0;0;0;False;0;False;0.5,0.56;0.5,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;8;-1038.337,158.2809;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;235;-664.9441,731.1721;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;234;-664.3779,638.1744;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SinTimeNode;118;-901.1569,972.76;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NegateNode;223;-610.8881,1563.84;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-1018.186,1371.396;Inherit;True;Property;_MainTexture;Main Texture;6;0;Create;True;0;0;0;False;0;False;-1;5042044934003d247ab4063321151b2f;958543e064f854b4ab4e1d2fc7935e63;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;65;-2369.959,-425.0164;Inherit;True;Property;_Flowmap;Flowmap;16;0;Create;True;0;0;0;False;0;False;-1;None;9c5f64e2ff566134ea551b699da2ce83;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;162;-493.8554,332.7429;Inherit;False;Property;_Mul;Mul;11;0;Create;True;0;0;0;False;0;False;0;2.59;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DistanceOpNode;9;-594.7726,67.25621;Inherit;True;2;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;186;-364.3807,-37.38207;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;221;-147.0019,951.6906;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;143;-403.8941,653.2161;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;172;-1978.46,-208.2807;Inherit;False;Property;_Alpha;Alpha;12;0;Create;True;0;0;0;False;0;False;0;0.05;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;177;-2018.71,-421.8997;Inherit;False;FLOAT4;4;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.LerpOp;178;-1766.992,-560.0419;Inherit;True;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.CommentaryNode;128;-1160.432,-663.5362;Inherit;False;381.4142;709.5647;Manejo de canales;3;100;102;26;;1,1,1,1;0;0
Node;AmplifyShaderEditor.StepOpNode;210;-58.8704,-129.1757;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0.35;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;237;-103.3964,610.7719;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;236;0.9729781,765.3931;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;225;380.7691,689.8494;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;26;-1110.432,-183.9715;Inherit;True;Property;_RenderTexture;Render Texture;15;0;Create;True;0;0;0;False;0;False;-1;622ce35a9648aa24e938a92c7e065959;58714b3ef209308468e6a1ac1969788f;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;233;170.9428,506.7843;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;100;-1108.118,-399.2969;Inherit;True;Property;_TextureSample0;Texture Sample 0;15;0;Create;True;0;0;0;False;0;False;-1;None;58714b3ef209308468e6a1ac1969788f;True;0;False;white;Auto;False;Instance;26;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;102;-1100.018,-613.5364;Inherit;True;Property;_TextureSample1;Texture Sample 1;18;0;Create;True;0;0;0;False;0;False;-1;None;58714b3ef209308468e6a1ac1969788f;True;0;False;white;Auto;False;Instance;26;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;226;766.7864,610.1536;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GrabScreenPosition;76;-697.5955,-759.6688;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;238;-317.4227,-416.6033;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;139;483.1555,280.3388;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ScreenColorNode;36;720.1448,-495.4236;Inherit;False;Global;_GrabScreen0;Grab Screen 0;6;0;Create;True;0;0;0;False;0;False;Object;-1;False;False;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1001.686,134.4414;Float;False;True;-1;6;ASEMaterialInspector;0;0;Standard;Portal;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;5;True;False;0;True;Transparent;;Transparent;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;True;2;15;10;25;False;5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;5;-1;-1;0;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;130;0;129;0
WireConnection;64;0;132;0
WireConnection;64;1;131;0
WireConnection;64;2;130;0
WireConnection;200;0;176;0
WireConnection;200;2;228;0
WireConnection;200;1;201;0
WireConnection;235;0;119;0
WireConnection;234;0;2;0
WireConnection;223;0;222;0
WireConnection;1;1;64;0
WireConnection;65;1;200;0
WireConnection;9;0;8;0
WireConnection;9;1;151;0
WireConnection;186;0;9;0
WireConnection;186;1;162;0
WireConnection;221;0;1;0
WireConnection;221;1;223;0
WireConnection;143;0;234;0
WireConnection;143;1;235;0
WireConnection;143;2;118;3
WireConnection;177;0;65;0
WireConnection;178;0;176;0
WireConnection;178;1;177;0
WireConnection;178;2;172;0
WireConnection;210;0;186;0
WireConnection;237;0;143;0
WireConnection;236;0;221;0
WireConnection;225;0;210;0
WireConnection;225;1;221;0
WireConnection;26;1;178;0
WireConnection;233;0;237;0
WireConnection;233;1;236;0
WireConnection;100;1;178;0
WireConnection;102;1;178;0
WireConnection;226;0;225;0
WireConnection;238;0;26;0
WireConnection;238;1;100;0
WireConnection;139;0;233;0
WireConnection;0;0;238;0
WireConnection;0;2;139;0
WireConnection;0;9;226;0
ASEEND*/
//CHKSM=78E0A6C324418C03641FAD8F7398DC453E448E97