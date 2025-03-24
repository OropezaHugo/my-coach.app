export interface UserModel {
  id: number,
  name: string,
  email: string,
  endpoint: string,
  auth: string,
  p256dh: string,
  avatarUrl: string,
  birthday: string,
  roleId: number,
}

export interface UserData {
  name: string,
  email: string,
  endpoint: string,
  auth: string,
  p256dh: string,
  avatarUrl: string,
  birthday: string,
  roleId: number,
}
