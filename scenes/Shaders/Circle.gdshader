shader_type canvas_item;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	vec2 uv = UV;
	float d = length(uv - 0.5);
	COLOR = texture(TEXTURE, UV);
	if (d > 0.5) {
		COLOR.a = 0.0;
	}
	// Called for every pixel the material is visible on.
}

//void light() {
	// Called for every pixel for every light affecting the CanvasItem.
	// Uncomment to replace the default light processing function with this one.
//}
