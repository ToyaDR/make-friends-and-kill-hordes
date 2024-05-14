shader_type spatial;

uniform float iridescence_strength : hint_range(0.0, 1.0) = 0.5;
uniform float iridescence_frequency : hint_range(0.0, 10.0) = 1.0;
uniform float iridescence_speed : hint_range(0.0, 10.0) = 1.0;

void fragment() {
    // Calculate the world position of the fragment
    vec3 world_pos = (MODEL_MATRIX * vec4(VERTEX, 1.0)).xyz;

    // Calculate the direction from the fragment to the camera
    vec3 to_camera = normalize(vec3(SCREEN_UV - vec2(0.5, 0.5),0.0));

    // Calculate the direction from the fragment to the object origin
    vec3 to_object = normalize(world_pos - vec3(0.0));

    // Calculate the angle between the fragment's view direction and the direction to the object origin
    float angle = acos(dot(to_camera, to_object));

    // Calculate the iridescent color based on the angle and parameters
    vec3 iridescent_color = vec3(
        sin(angle * iridescence_frequency + TIME * iridescence_speed),
        sin(angle * iridescence_frequency + TIME * iridescence_speed + 2.0),
        sin(angle * iridescence_frequency + TIME * iridescence_speed + 4.0)
    );

    // Mix the base color with the iridescent color
    vec3 final_color = mix(ALBEDO.rgb, iridescent_color, iridescence_strength);

    // Output the final color
    ALBEDO = vec4(final_color, vec4(ALBEDO,0.0).a);
}
