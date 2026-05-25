import { useState } from 'react';
import type { Visitor } from '../types';
import { createLogger } from '../utils/logger';
import { getInitialVisitors, registerNewVisitor } from '../api/visitorApi';

const log = createLogger('UseVisitorsHook');

export const useVisitors = (addToast: (msg: string, type: 'success' | 'warning' | 'danger' | 'info') => void) => {
  const [visitors, setVisitors] = useState<Visitor[]>(() => getInitialVisitors());
  const [visitorName, setVisitorName] = useState<string>('');
  const [visitorPurpose, setVisitorPurpose] = useState<string>('Family Visit');
  const [activeVisitorPass, setActiveVisitorPass] = useState<Visitor | null>(null);

  const handleRegisterVisitor = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!visitorName.trim()) {
      log.warn('Visitor registration skipped due to empty guest name field.');
      return;
    }

    log.info('Submitting guest registration credentials', { name: visitorName, purpose: visitorPurpose });

    try {
      const newVisitor = await registerNewVisitor(visitorName.trim(), visitorPurpose);
      setVisitors(prev => [newVisitor, ...prev]);
      setActiveVisitorPass(newVisitor);
      setVisitorName('');
      addToast(`Visitor registered & host validation approved! Pass Code: ${newVisitor.code}`, 'success');
    } catch (err: any) {
      addToast('🚨 An error occurred during guest registration.', 'danger');
      log.error('Visitor registration failed', { error: err.message });
    }
  };

  return {
    visitors,
    visitorName,
    visitorPurpose,
    activeVisitorPass,
    setVisitorName,
    setVisitorPurpose,
    setActiveVisitorPass,
    handleRegisterVisitor
  };
};
