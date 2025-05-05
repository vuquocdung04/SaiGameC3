# SaiGameC3

Hành trình học 100 tập tutorial C3 từ kênh SaiGame.

## Nội dung học được

### Tuần 1 (6/2 - 9/2)
- **Singleton & Pooling**: Generic class cho singleton
- **Spawners**: Hệ thống spawn/despawn
- **Quaternion**: Hiểu về Gimbal Lock
- **Damage System**: Cấu trúc gửi/nhận damage
- **Resources & AddressAble**: Quản lý tài nguyên
- **Item System**: Drop rate và inventory cơ bản

### Tuần 2 (10/2 - 15/2)
- **Inventory**: Quản lý đồ vật
- **UI**: Tích hợp icon vào TextMeshPro
- **Movement**: Logic di chuyển theo đường thẳng
- **Abilities**: Dash và Warp
- **Optimization**: SetText(), SetParent() và Static Rigidbody2D
- **Component Linking**: Liên kết không trực tiếp

## Kiến trúc Code
- Giao tiếp qua Controller (Ctrl)
- Abstract class với LoadCtrl()
- Controller là singleton
- Parent objects gọi trực tiếp child objects