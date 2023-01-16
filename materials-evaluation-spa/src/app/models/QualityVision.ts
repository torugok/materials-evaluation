import { Material } from './Material';

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
  type: string;
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
