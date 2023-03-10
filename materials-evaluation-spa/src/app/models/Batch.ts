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
  resultQualitative: boolean | null;
  resultQuantitative: number | null;
}

export interface Batch {
  id: string;
  material: Material;
  qualityVision: QualityVision;
  createdAt: string;
  amountOfTests: number;
  calculatedAt: string | null;
  status: Status;
  tests: Test[];
}
