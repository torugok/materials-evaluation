enum QualityType {
  Quantitative = 'QUANTITATIVE',
  Qualitative = 'QUALITATIVE',
}

export interface QualityProperty {
  id: number;
  acronym: string;
  type: QualityType;
}
