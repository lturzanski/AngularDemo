export interface StateExclExclusion {
  Id: number;
  ExclusionName: string;
  ExclusionDescription: string;
}

export interface StateExclExclusionDate {
  Id: number;
  ExclusionDate: string;
  StateExcl_ExclusionId: number;
}

export interface StateExclState {
  Id: number;
  StateName: string;
  StateAbbreviation: string;
}

export interface StateExclStateExclusion {
  Id: number;
  StateExcl_StateId: number;
  StateExcl_ExclusionId: number;
}

export interface StateExclusionView {
  StateName: string;
  StateAbbreviation: string;
  StateExclusionId: number;
  ExclusionName: string;
  ExclusionDescription: string;
  StateId: number;
  ExclusionId: number;
  ExclusionDateId: number;
  ExclusionDate: string;
}
