export interface Exclusion {
  Id: number;
  ExclusionName: string;
  ExclusionDescription: string;
}

export interface ExclusionDate {
  Id: number;
  Date: string;
  ExclusionId: number;
}

export interface State {
  Id: number;
  StateName: string;
  StateAbbreviation: string;
}

export interface StateExclusion {
  Id: number;
  StateId: number;
  ExclusionId: number;
}

export interface StateExclusionView {
  StateName: string;
  StateAbbreviation: string;
  StateExclusionId: number;
  ExclusionName: string;
  ExclusionDescription: string;
  Date: string;
  StateId: number;
  ExclusionId: number;
  ExclusionDateId: number;
}
