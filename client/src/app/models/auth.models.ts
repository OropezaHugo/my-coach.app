export interface GoogleUserInfo {
  at_hash: string;
  aud: string;
  azp: string;
  email: string;
  email_verified: boolean;
  exp: number;
  family_name: string;
  given_name: string;
  iat: number;
  iss: string;
  name: string;
  picture: string;
  sub: string;
  role: string;
}

export const ROLES_IDS: Record<string, number> = {
  "Coach": 1,
  "Student": 2,
  "Guest": 3,
};
