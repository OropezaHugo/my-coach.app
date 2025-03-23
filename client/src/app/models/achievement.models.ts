export interface UserAchievementModel {
  id: number;
  userId: number;
  achievementId: number;
  achievementStepsProgress: number;
  achievementActualLevel: number;
  achievementName: string;
  achievementImage: string;
  obtainingDescription: string;
  achievementStepsPerLevel: number[];
  exerciseId: number;
}

export const LEVEL_COLORS: Record<number, string> = {
  1: "#CD7F32",
  2: "#C0C0C0",
  3: "#FFD72F",
  4: "#8A2BE2",
  5: "#800020",
  6: "#A5E4FF",
};
