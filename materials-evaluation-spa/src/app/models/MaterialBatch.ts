import { Material } from './Material';
import { QualityProperty } from './QualityProperty';
import { QualityVision } from './QualityVision';

export enum Status {
  Pending,
  OutOfRange,
  InRange,
}

export interface Test {
  qualityProperty: QualityProperty;
  createdAt: string;
  resultQualitative: boolean | null;
  resultQuantitative: number | null;
}

export interface MaterialBatch {
  id: string;
  material: Material;
  qualityVision: QualityVision;
  createdAt: string;
  amountOfTests: number;
  calculatedAt: string | null;
  status: Status;
  tests: Test[];
}
