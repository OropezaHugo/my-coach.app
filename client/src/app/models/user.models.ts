export interface UserModel {
  id: number,
  name: string,
  email: string,
  password: string,
  avatarUrl: string,
  birthday: string,
  roleId: number,
}

export interface UserData {
  name: string,
  email: string,
  password: string,
  avatarUrl: string,
  birthday: string,
  roleId: number,
}
