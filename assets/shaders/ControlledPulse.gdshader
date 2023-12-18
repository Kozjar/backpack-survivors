shader_type canvas_item;

uniform float progress = 0.5;

void fragment() {
	COLOR = vec4(vec3(1.0), (sin(progress * 2.0 * PI - PI / 2.0) + 1.0) * 0.6);
}
