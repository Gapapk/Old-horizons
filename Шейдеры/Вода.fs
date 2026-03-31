P_COLOR vec4 FragmentKernel(P_UV vec2 texCoord) {

    texCoord.x += 0.01 * sin(texCoord.y * 25.0 + 4.0 * texCoord.x + CoronaTotalTime * 10.0);
    texCoord.y += 0.01 * cos(texCoord.x * 25.0 + 4.0 * texCoord.y + CoronaTotalTime * 10.0);

    P_COLOR vec4 texColor = texture2D(CoronaSampler0, texCoord);
    
    texColor.rgb -= sin(texCoord.y * 25.0 + 4.0 * texCoord.x + CoronaTotalTime * 10.0) * 0.05;
    
    P_DEFAULT vec4 adjLight = CoronaVertexUserData;
    adjLight.rgba /= 16.;
    
    P_DEFAULT float light = ((((1. - texCoord.x) * adjLight.r) + (texCoord.x * adjLight.g)) +
    (((1. - texCoord.y) * adjLight.b) + (texCoord.y * adjLight.a))) / 2. + 0.15;
    
    texColor.r *= light * 1.17;
    texColor.g *= light * 1.1;
    texColor.b *= light + 0.1 * (1. - light);

    return CoronaColorScale(texColor);
}
