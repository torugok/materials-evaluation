enum QualityType {
  Quantitative = 'Quantitative',
  Qualitative = 'Qualitative',
}

export interface QualityProperty {
  id: string;
  acronym: string;
  description: string;
  type: QualityType;

  // apenas para tipo Quantitative
  quantitativeDecimals: number;
  quantitativeUnit: string;
  quantitativeNominalValue: number;
  quantitativeInferiorLimit: number;
  quantitativeSuperiorLimit: number;
}
