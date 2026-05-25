export type AuraAIDiagnosis = {
  title: string;
  description: string;
  severity: 'Small' | 'Big';
  diySteps: string[];
  confidence: number;
};

export type Ticket = {
  id: number;
  title: string;
  description: string;
  status: string;
  priority: string;
  assignedTo: string;
  createdAt: string;
  imageUrl?: string;
  diagnosisResult?: string;
  severity: string;
};

export type EscalationPayload = {
  title: string;
  description: string;
  imageUrl: string;
  diagnosis: string;
};
