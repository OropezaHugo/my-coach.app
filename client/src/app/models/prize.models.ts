export interface PrizeModel {
  id: number;
  prizeName: string;
  prizeImage: string;
  points: number;
}

export interface PrizeData {
  prizeName: string;
  prizeImage: string;
  points: number;
}

export interface RewardUserDialogData {
  userId: number;
}

export interface AddPrizeToUserData {
  prizeId: number;
  userId: number;
}
export interface UserPrizeInfoModel {
  id: number;
  prizeId: number;
  userId: number;
  prizeName: string;
  prizeImage: string;
  points: number;
}
