import { useState, useEffect } from 'react';
import type { Ticket, Diagnosis } from '../types';
import { createLogger } from '../utils/logger';
import { escalateResidentTicket } from '../api/ticketApi';

const log = createLogger('UseAuraAIHook');

// Visual Avatars using inline SVG wrappers for pure offline capability
const TechAvatars = {
  gas: `data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" width="100%" height="100%"><rect width="100%" height="100%" fill="%231a252f"/><circle cx="50" cy="40" r="20" fill="%23e67e22"/><path d="M20 80c0-15 15-20 30-20s30 5 30 20v10H20V80z" fill="%2334495e"/><rect x="40" y="55" width="20" height="20" rx="3" fill="%237f8c8d"/><circle cx="45" cy="38" r="2" fill="%23000"/><circle cx="55" cy="38" r="2" fill="%23000"/></svg>`,
  water: `data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" width="100%" height="100%"><rect width="100%" height="100%" fill="%231e272e"/><circle cx="50" cy="40" r="20" fill="%23fad390"/><path d="M20 80c0-15 15-20 30-20s30 5 30 20v10H20V80z" fill="%230a3d62"/><path d="M35 30c5-10 25-10 30 0s0 20-15 20-15-10-15-20z" fill="%232c3e50" opacity="0.8"/><circle cx="45" cy="40" r="2" fill="%23000"/><circle cx="55" cy="40" r="2" fill="%23000"/></svg>`,
  electrical: `data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" width="100%" height="100%"><rect width="100%" height="100%" fill="%232c3e50"/><circle cx="50" cy="40" r="20" fill="%23e056fd"/><path d="M20 80c0-15 15-20 30-20s30 5 30 20v10H20V80z" fill="%231e272e"/><rect x="42" y="30" width="16" height="6" fill="%23f1c40f"/><circle cx="45" cy="40" r="2" fill="%23000"/><circle cx="55" cy="40" r="2" fill="%23000"/></svg>`
};

const Diagnoses: Record<'drain' | 'pipe' | 'socket' | 'gas', Diagnosis> = {
  drain: {
    name: 'Slow Drain Faucet Anomaly',
    severity: 'Small',
    confidence: '97% Match',
    desc: 'Minor fluid-dynamics restriction identified in structural basin drainpipe. Likely organic hair/soap buildup. Pressure and gas indexes nominal.',
    steps: [
      'Pour 1/2 cup of baking soda down the drain basin.',
      'Follow immediately with 1/2 cup of white vinegar. Cover the drain plug.',
      'Wait 15 minutes, allowing chemical reaction to dissolve bio-blockage.',
      'Flush fully with 1 Liter of boiling water to normalize drain speed.'
    ]
  },
  pipe: {
    name: 'High-Pressure Pipe Fracture',
    severity: 'Big',
    confidence: '99% Match',
    desc: 'Critical water line rupture identified on primary feed pipe. Flow telemetry shows pressure discharge at 65 PSI. Fast escalation advised to mitigate severe flooding.',
    techSpec: {
      name: 'Water Systems Specialist',
      role: 'Water Systems Specialist',
      rating: '⭐ 4.91',
      vehicle: 'Blue Chevrolet Express - WH921',
      photo: TechAvatars.water,
      eta: '8 mins'
    }
  },
  socket: {
    name: 'Exposed Electrical Arc Hazard',
    severity: 'Big',
    confidence: '96% Match',
    desc: 'Thermal blackening and carbonation detected around dual 120V outlet socket. Internal micro-arcing hazard identified. Critical risk of electrical fire.',
    techSpec: {
      name: 'Electrical Grid Specialist',
      role: 'Master Electrician',
      rating: '⭐ 4.88',
      vehicle: 'Grey Ram Cargo - PK501',
      photo: TechAvatars.electrical,
      eta: '7 mins'
    }
  },
  gas: {
    name: 'Primary Gas Regulator Fracture',
    severity: 'Big',
    confidence: '98% Match',
    desc: 'Critical valve corrosion and structural micro-leakage identified on main butane lines. Ambient sensors indicate gas PPM concentrations exceeding hazardous limits. Explosive atmosphere risks present!',
    techSpec: {
      name: 'Gas Grid Systems Specialist',
      role: 'Gas Grid Specialist',
      rating: '⭐ 4.95',
      vehicle: 'White Ford Transit - NV892',
      photo: TechAvatars.gas,
      eta: '5 mins'
    }
  }
};

export const useAuraAI = (
  addToast: (msg: string, type: 'success' | 'warning' | 'danger' | 'info') => void,
  addTicket: (ticket: Ticket) => void
) => {
  const [selectedPreset, setSelectedPreset] = useState<'drain' | 'pipe' | 'socket' | 'gas' | null>(null);
  const [isScanning, setIsScanning] = useState<boolean>(false);
  const [scanResult, setScanResult] = useState<Diagnosis | null>(null);
  const [diyStepsCompleted, setDiyStepsCompleted] = useState<Record<number, boolean>>({});

  // 1. Deep-linking restoring on boot
  useEffect(() => {
    const params = new URLSearchParams(window.location.search);
    const presetParam = params.get('preset');
    if (presetParam === 'drain' || presetParam === 'pipe' || presetParam === 'socket' || presetParam === 'gas') {
      log.info('Deep-linked armed AI preset restored', { presetParam });
      setSelectedPreset(presetParam);
    }
  }, []);

  // 2. Synchronize armed preset to URL search parameters
  useEffect(() => {
    const params = new URLSearchParams(window.location.search);
    
    // Read current parameters to preserve them
    if (selectedPreset) {
      params.set('preset', selectedPreset);
    } else {
      params.delete('preset');
    }
    
    const cleanQuery = params.toString();
    const relativePath = window.location.pathname + (cleanQuery ? `?${cleanQuery}` : '');
    
    if (window.location.search !== `?${cleanQuery}`) {
      window.history.replaceState(null, '', relativePath);
      log.debug('AuraAI Preset deep-linking synchronized', { selectedPreset });
    }
  }, [selectedPreset]);

  // Actions
  const handlePresetSelect = (preset: 'drain' | 'pipe' | 'socket' | 'gas') => {
    log.debug('Visual camera armed with issue scenario preset', { preset });
    setSelectedPreset(preset);
    setScanResult(null);
    setDiyStepsCompleted({});
    addToast(`Preset loaded. Camera frame armed. Ready for scan.`, 'info');
  };

  const handleLaunchAnalysis = () => {
    if (!selectedPreset) {
      log.warn('AuraAI scan skipped because no preset was armed.');
      return;
    }

    setIsScanning(true);
    setScanResult(null);
    addToast('AuraAI Neural Inspector active. Analyzing visual components...', 'warning');
    log.info('AuraAI Neural Inspector scanning cycle initialized', { preset: selectedPreset });

    const logs = [
      'Scanning component integrity indicators...',
      'Computing fluid-dynamics pressure vectors...',
      'Assessing hazard index ratings...',
      'Diagnostic complete!'
    ];

    logs.forEach((logVal, index) => {
      setTimeout(() => {
        addToast(`AI Core: ${logVal}`, index === logs.length - 1 ? 'success' : 'info');
        log.debug('AuraAI core calculation sub-step resolved', { telemetryFeed: logVal });
        
        if (index === logs.length - 1) {
          setIsScanning(false);
          const formulatedResult = Diagnoses[selectedPreset];
          setScanResult(formulatedResult);
          log.info('AuraAI Neural Inspector cycle complete. Anomaly diagnosed.', {
            preset: selectedPreset,
            severity: formulatedResult.severity,
            confidence: formulatedResult.confidence
          });
        }
      }, (index + 1) * 700);
    });
  };

  const toggleDiyStep = (idx: number) => {
    const isCompletedNow = !diyStepsCompleted[idx];
    log.debug('Interactive DIY recovery guide directive status changed', {
      stepIndex: idx,
      completed: isCompletedNow
    });
    setDiyStepsCompleted(prev => ({
      ...prev,
      [idx]: isCompletedNow
    }));
  };

  const handleEscalateTicket = async () => {
    if (!selectedPreset || !scanResult) {
      log.warn('Work order escalation rejected due to empty diagnostic values.');
      return;
    }

    try {
      const newTicket = await escalateResidentTicket(selectedPreset, scanResult);
      addTicket(newTicket);
      addToast(`Work Order ${newTicket.id} created & dispatched to Building Admin.`, 'success');
      
      // Reset AI Diagnostic frame
      setScanResult(null);
      setSelectedPreset(null);
    } catch (err: any) {
      addToast('🚨 Work order escalation failed.', 'danger');
      log.error('Escalation error', { error: err.message });
    }
  };

  const discardDiagnosis = () => {
    setScanResult(null);
    setSelectedPreset(null);
    setDiyStepsCompleted({});
  };

  return {
    selectedPreset,
    isScanning,
    scanResult,
    diyStepsCompleted,
    handlePresetSelect,
    handleLaunchAnalysis,
    toggleDiyStep,
    handleEscalateTicket,
    discardDiagnosis
  };
};
