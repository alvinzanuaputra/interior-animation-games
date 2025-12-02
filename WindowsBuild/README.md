# 3D Interior Animation Games

Proyek ini merupakan Final Project untuk mata kuliah Grafika Komputer. Aplikasi ini adalah simulasi atau game animasi interior 3D yang dikembangkan menggunakan Unity.

## Catatan Penting Mengenai File Proyek

Dikarenakan ukuran build dan aset proyek yang sangat besar, file lengkap proyek ini tidak disimpan langsung di dalam repositori ini. Kami memutuskan untuk menyimpan file utama dan build aplikasi di Google Drive untuk memudahkan akses dan pengelolaan.

Anda dapat mengunduh file proyek lengkap melalui tautan berikut:

https://drive.google.com/drive/folders/1IvfkEAZCjZfhmrJ5U3cQGllWP8FN9xD_?usp=sharing

## Tentang Proyek

Proyek ini menampilkan lingkungan interior 3D yang interaktif. Pengguna dapat menjelajahi ruangan dan melihat berbagai elemen grafis yang diterapkan, seperti pencahayaan, tekstur, dan model 3D yang mendetail. Tujuannya adalah untuk mendemonstrasikan teknik-teknik grafika komputer dalam lingkungan real-time.

## Fitur dan Implementasi

Berikut adalah rincian elemen-elemen grafis yang diimplementasikan dalam proyek ini:

### Animasi
Proyek ini mencakup sistem animasi untuk pergerakan karakter dan interaksi objek dalam ruangan. Animasi dirancang untuk memberikan kesan realistis saat pengguna menjelajahi lingkungan interior.

### Interaksi Fisika (Physics Interaction)
Fitur interaksi memungkinkan pemain untuk memanipulasi objek dalam scene.
- **Memindahkan Barang**: Implementasi skrip `PhysicsPickup.cs` dan `ObjectMover.cs` memungkinkan pemain untuk mengangkat dan memindahkan objek seperti kardus (`cardboard_box`).
- **Objek Solid**: Objek-objek dalam lingkungan memiliki properti fisik (collider) yang membuatnya terasa padat dan realistis saat berinteraksi dengan pemain atau objek lain.

### Efek Visual (Visual Effects)
Penggunaan efek visual (VFX) diterapkan untuk meningkatkan atmosfer ruangan. Ini termasuk partikel debu, efek cahaya volumetrik, atau elemen visual dinamis lainnya yang terdapat dalam folder `Vefects`.

### Shader dan Material
Berbagai material dan shader kustom digunakan untuk memberikan tekstur yang detail pada furnitur, dinding, dan lantai. Pengaturan material disesuaikan untuk merespons pencahayaan secara akurat.

### Pencahayaan (Lighting)
Sistem pencahayaan menggunakan kombinasi *real-time* dan *baked lighting* untuk menciptakan suasana yang mendalam. Pengaturan *Global Illumination* dan *Reflection Probes* digunakan untuk memastikan pantulan cahaya yang realistis pada permukaan objek.

## Struktur Folder Proyek

Untuk memudahkan navigasi dalam proyek Unity ini, berikut adalah struktur folder utama yang ada di dalam `Assets`:

- **Scenes**: Berisi file scene utama proyek.
- **StarterAssets**: Berisi aset dasar yang digunakan, seperti kontroler karakter (First/Third Person Controller).
- **Vefects**: Berisi aset dan prefab untuk efek visual (Visual Effects).
- **Settings**: Berisi profil pengaturan render pipeline dan konfigurasi proyek lainnya.
- **Assets**: Folder utama pengembangan yang berisi aset kustom proyek:
    - **Scripts**: Berisi logika permainan seperti `PhysicsPickup.cs`, `ObjectMover.cs`, `PlayerInteraction.cs`, dll.
    - **Models**: Berisi model 3D (FBX) seperti `cardboard_box`, furnitur, dan properti lingkungan lainnya.
    - **Prefabs**: Berisi objek yang sudah dikonfigurasi (Prefab) siap pakai di scene.
    - **Materials**: Berisi material yang diterapkan pada model 3D.
    - **SFX**: Berisi efek suara.
