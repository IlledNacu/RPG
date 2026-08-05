# 1) Jugador con movimiento en x/y
<img width="684" height="92" alt="image" src="https://github.com/user-attachments/assets/4e7cadec-f13b-4235-811c-ea66b40004d3" />
<img width="686" height="493" alt="image" src="https://github.com/user-attachments/assets/a0528f04-5686-41cc-a042-239081852c45" />
<img width="673" height="560" alt="image" src="https://github.com/user-attachments/assets/d4c7c6e3-8b67-41a6-a602-6fa657dc53f1" />
<br>GitAxis Horizontal/Vertical quedó deprecado; ahora se usa el InputAction, que se setea manualmente desde el motor, en el script del personaje.
<br>Free Asset Package from: https://pixelfrog-assets.itch.io/tiny-swords

# 2) Animaciones: idle, walk & run

<img width="914" height="186" alt="image" src="https://github.com/user-attachments/assets/72b87fd6-962f-4c1e-a014-40334c18866e" />
<br>Se arrastran los sprites, se duplica el último para hacer más fluido el loop y se extiende la duración de la animación en el tiempo para ralentalizarla.
<img width="931" height="247" alt="image" src="https://github.com/user-attachments/assets/1e2bd78d-dc0c-45a5-a99f-682bbc8a0246" />
<br>Se crean las transiciones entre una animación a otra y los parámetros a ser usados en las condiciones.
<img width="1176" height="601" alt="image" src="https://github.com/user-attachments/assets/589f1141-4d8a-45fe-9c6e-5e5f8410bb6b" />
<img width="1172" height="620" alt="image" src="https://github.com/user-attachments/assets/3700c223-9eec-4d98-841f-6f9892ab429b" />
<img width="1166" height="600" alt="image" src="https://github.com/user-attachments/assets/6dac95cb-f902-4b46-906f-94348976c18c" />
<br>Se destilda el Has exit time, se pone en 0 la Transition duration y se crean las condiciones de transición.
<img width="871" height="769" alt="image" src="https://github.com/user-attachments/assets/f1a1fef3-1966-4740-951e-69499f4c4475" />
<br>Modificamos el script para agregar las variables de runSpeed, runAction (para setear desde el motor en el Shift) y de movimiento, establecemos la transición de una animación a otra en función del estado del personaje y el Flip (volteo).
<br>Es necesario, desde el motor, arrastrar la caja del Animator dentro de la variable Anim declarada en el script del personaje.
