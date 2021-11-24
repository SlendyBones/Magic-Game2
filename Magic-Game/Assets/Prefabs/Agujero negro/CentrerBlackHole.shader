// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CentrerBlackHole"
{
	Properties
	{
		_Bias("Bias", Float) = 0
		_NegativeBias("Negative Bias", Float) = 0
		_Scale("Scale", Float) = 0
		_NegativeScale("Negative Scale", Float) = 0
		_Power0("Power 0", Float) = 0
		_NegativePower("Negative Power", Float) = 0
		_Color0("Color 0", Color) = (0.8490566,0.7603308,0,1)
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Unlit alpha:fade keepalpha noshadow 
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
			float3 viewDir;
		};

		uniform float4 _Color0;
		uniform float _Bias;
		uniform float _Scale;
		uniform float _Power0;
		uniform float _NegativeBias;
		uniform float _NegativeScale;
		uniform float _NegativePower;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			o.Emission = saturate( _Color0 ).rgb;
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_worldNormal = i.worldNormal;
			float fresnelNdotV9 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode9 = ( _Bias + _Scale * pow( max( 1.0 - fresnelNdotV9 , 0.0001 ), _Power0 ) );
			float fresnelNdotV141 = dot( ase_worldNormal, -i.viewDir );
			float fresnelNode141 = ( _NegativeBias + _NegativeScale * pow( 1.0 - fresnelNdotV141, _NegativePower ) );
			o.Alpha = saturate( ( saturate( fresnelNode9 ) * saturate( fresnelNode141 ) ) );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
507;73;887;617;638.1948;989.6891;2.172525;True;False
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;133;-1015.712,-95.17689;Inherit;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;127;-727.6791,1.460576;Inherit;False;Property;_NegativeBias;Negative Bias;1;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;126;-724.9215,88.03268;Inherit;False;Property;_NegativeScale;Negative Scale;4;0;Create;True;0;0;0;False;0;False;0;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.NegateNode;134;-677.1839,-71.22626;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;27;-737.6838,-266.2749;Inherit;False;Property;_Scale;Scale;3;0;Create;True;0;0;0;False;0;False;0;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;128;-721.5936,167.6837;Inherit;False;Property;_NegativePower;Negative Power;6;0;Create;True;0;0;0;False;0;False;0;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;26;-719.8492,-371.5878;Inherit;False;Property;_Bias;Bias;0;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;28;-725.256,-165.8239;Inherit;False;Property;_Power0;Power 0;5;0;Create;True;0;0;0;False;0;False;0;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FresnelNode;9;-423.389,-405.9476;Inherit;True;Standard;WorldNormal;ViewDir;False;True;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.FresnelNode;141;-449.5317,-77.00699;Inherit;True;Standard;WorldNormal;ViewDir;False;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;40;-41.15018,-334.752;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;131;-74.3384,-95.40033;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;132;123.8753,-207.5;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;31;-176.3412,-618.7366;Inherit;False;Property;_Color0;Color 0;7;0;Create;True;0;0;0;False;0;False;0.8490566,0.7603308,0,1;0,0.841821,0.9528302,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PosVertexDataNode;143;-771.5383,682.3884;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCRemapNode;142;-279.6773,650.8829;Inherit;True;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;45;-1518.734,582.0897;Inherit;False;Property;_Speed;Speed;9;0;Create;True;0;0;0;False;0;False;0;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;122;-1391.376,459.4255;Inherit;False;Property;_Vector0;Vector 0;10;0;Create;True;0;0;0;False;0;False;0,-1;0,-1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;47;-1341.331,625.9594;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;43;-1531.953,191.8895;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;145;-493.3857,808.085;Inherit;False;Property;_MinOld;Min Old;12;0;Create;True;0;0;0;False;0;False;0;0.27;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;146;-498.3857,891.085;Inherit;False;Property;_MaxOld;Max Old;14;0;Create;True;0;0;0;False;0;False;0;3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;148;-499.3857,1044.085;Inherit;False;Property;_MaxNew;Max New;11;0;Create;True;0;0;0;False;0;False;0;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;18;-1117.918,275.2444;Inherit;True;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,1;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;151;137.2381,210.9077;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;1;-780.0122,291.1979;Inherit;True;Property;_TextureSample0;Texture Sample 0;2;0;Create;True;0;0;0;False;0;False;-1;9f68f5cda7b156d438ab21b15cc8b536;9f68f5cda7b156d438ab21b15cc8b536;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;147;-496.3857,976.085;Inherit;False;Property;_MinNew;Min New;13;0;Create;True;0;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;44;-1812.422,164.6512;Inherit;False;Property;_Tilling;Tilling;8;0;Create;True;0;0;0;False;0;False;0;9;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;155;315.1599,-424.5304;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;156;-89.801,520.0974;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;125;392.6861,86.4244;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;140;-103.6157,235.0424;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;149;29.08305,379.5898;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;3;-448.3468,252.669;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;139;282.6338,-156.4479;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;655.1477,-118.0953;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;CentrerBlackHole;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;134;0;133;0
WireConnection;9;1;26;0
WireConnection;9;2;27;0
WireConnection;9;3;28;0
WireConnection;141;4;134;0
WireConnection;141;1;127;0
WireConnection;141;2;126;0
WireConnection;141;3;128;0
WireConnection;40;0;9;0
WireConnection;131;0;141;0
WireConnection;132;0;40;0
WireConnection;132;1;131;0
WireConnection;142;0;143;2
WireConnection;142;1;145;0
WireConnection;142;2;146;0
WireConnection;142;3;147;0
WireConnection;142;4;148;0
WireConnection;47;0;45;0
WireConnection;43;0;44;0
WireConnection;18;0;43;0
WireConnection;18;2;122;0
WireConnection;18;1;47;0
WireConnection;151;0;140;0
WireConnection;151;1;149;0
WireConnection;1;1;18;0
WireConnection;155;0;31;0
WireConnection;156;0;142;0
WireConnection;140;0;3;0
WireConnection;149;0;156;0
WireConnection;3;0;1;0
WireConnection;139;0;132;0
WireConnection;0;2;155;0
WireConnection;0;9;139;0
ASEEND*/
//CHKSM=E9B2200E32AE17F2E5DEDD0985E9B8348999234F