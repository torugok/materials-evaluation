enum QualityType {
  Quantitative = 'QUANTITATIVE',
  Qualitative = 'QUALITATIVE',
}

export interface QualityProperty {
  id: number;
  acronym: string;
  description: string;
  type: QualityType;

  // apenas para tipo QUANTITATIVE
  quantitativeDecimals: number;
  quantitativeUnit: string;
  quantitativeNominalValue: number;
  quantitativeInferiorLimit: number;
  quantitativeSuperiorLimit: number;
}
