import { QualityType } from './QualityProperty';

export enum Grouping {
  First,
  Last,
}

export enum CalculationType {
  Median,
}

export interface AvaliationMethodology {
  minQuantity: number;
  grouping: Grouping;
  calculationType: CalculationType;
}

export interface QuantitativeParams {
  decimals: number;
  unit: string;
  nominalValue: number;
  inferiorLimit: number;
  superiorLimit: number;
}

export interface QualityProperty {
  id: string;
  acronym: string;
  description: string;
  type: QualityType;
  quantitativeParams: QuantitativeParams;
}

export interface QualityVision {
  id: string;
  name: string;
  materialId: string;
  avaliationMethodology: AvaliationMethodology;
  qualityPropertiesIds: string[];
  qualityProperties?: QualityProperty[];
}

export interface TestResult {
  qualityPropertyId: string;
  qualityPropertyDescription: string;
  type: QualityType;
  resultQualitative: boolean | null;
  resultQuantitative: number | null;
  quantitativeParams: QuantitativeParams;
}
