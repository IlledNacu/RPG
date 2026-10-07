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

# 3) Tilemaps y elevaciones con colición

Se importa el pack de tilesets que vamos a usar a la carpeta de Sprites. Los seleccionamos y en el inspector nos aseguramos de que estén configurados de la siguiente manera:
<br><img width="290" height="475" alt="image" src="https://github.com/user-attachments/assets/1fb7143b-5dfb-40f2-be91-3806a2cfddab" />
<br>Luego seleccionamos uno y abrimos el Sprite editor, y arriba en Slice:
<br><img width="298" height="248" alt="image" src="https://github.com/user-attachments/assets/f2807728-2338-426a-af0f-6cc7c62c8b25" />
<br>Aplicamos los cambios. Esto lo repetimos con todos nuestros sets.
<br>Luego vamos a añadir en Hierarchy un nuevo 2D Object -> Tilemap -> Rectangular. El primero va a ser Ground.
<br>Para crear la paleta, vamos a Window -> 2D -> Tile Palette. (Podemos arrastrar la ventana como una pestaña junto al inspector, dentro de nuestro espacio de trabajo.) Vamos a crear una nueva paleta llamada Grass Tiles, vamos a crear su carpeta dentro de Sprites, y arrastramos los archivos que ya configuramos y separamos antes a la grilla.
<br>Para empezar a usar la paleta conviene activar la grilla del visualizador y empezamos a pintar eligiendo cada bloque según necesitemos. Hay diversas herramientas de pintura.
<br>Vamos a volver al inspector de Ground y en Adittional Settings cambiar Order in Layer a -1 para que no se superponga al Player. Luego creamos dos 2D Object -> Tilemap -> Rectangular más: Decorations (Order in Layer = 0) y Elevations (Order in Layer = 1); y cambiamos el Order in Layer del Player a 5. A Elevations le agregamos un componente: Tilemap Collider 2D.


# 4) Colisiones en el espacio

Para aplicar colisiones en los tilemaps, creamos 4 grados de tilemaps distintos: aquellos que no tienen colisión y tienen un Order in Layer menor al personaje (el suelo), aquellos que sí tienen colisión y tienen un orden menor al personaje (las bases de estructuras o elementos), aquellos que no tienen colisión y tienen un orden mayor al personaje (la parte alta de estructuras o elementos, la cual el personaje pasa por "detrás") y aquellos que tienen colisión y tienen un orden mayor al personaje (estructuras o partes de elementos que el personaje choca y no puede superponerse).

# 5) Cambio de colisiones para representar un cambio de nivel del suelo del personaje

Para usar escaleras y subir o bajar un nivel del suelo usamos dos scripts: Elevation_Entry y Elevation_Exit. Las escaleras están en el nivel de Non-collision-Low, así que a dicho objeto le agregamos el componente Script -> Elevation_Entry. En el inspector aparecen inputs para agregar los MountainColliders (Collision-High y Collision-Low) y el MountainBoundary (al que vamos a arrastrar el tilemap que hagamos después):
<br><img width="333" height="662" alt="image" src="https://github.com/user-attachments/assets/e46fd693-8ec5-4489-86e7-6abdf606608a" />
<br>El Box collider de cada escalera tiene que ajustarse al escalón superior y estar seteado como Trigger.
<br>Para que funcione correctamente, el Player tiene que figurar en el inspector con el Tag de Player, ya que a través del tag es como lo captura el script.
<br>Se crea un tilemap MountainBoundary que va a marcar los límites de las estructuras elevadas que el personaje no debe atravesar, ni arriba ni abajo. Usamos un tilemap cualquiera y lo ponemos invisible, e inicialmente con un collider desactivado.
<br>Luego para el Exit hay que desactivar el boundary. Se crea un objeto vacío dentro de Non-collision-Low con el nombre Exits y con un componente Box Collider 2D (seteado como Trigger) en el último escalón inferior de cada escalera delimitamos la "salida" del espacio elevado. A este objeto también le agregamos el componente Script -> Elevation_Exit, con los mismos MountainColliders y MountainBoundary.
